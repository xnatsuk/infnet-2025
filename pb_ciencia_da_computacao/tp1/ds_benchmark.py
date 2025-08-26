# from __future__ import annotations
import time
import tracemalloc
from abc import ABC, abstractmethod
from collections import deque
from pathlib import Path
from typing import Any, Dict, List, Tuple


def read_listing(path: str | Path) -> List[str]:
    with open(path, encoding="utf-8") as file:
        return [line.split("\t")[0].strip() for line in file if line.strip()]


def benchmark(func, *args, **kwargs) -> Tuple[float, int, Any]:
    tracemalloc.start()
    t0 = time.perf_counter()
    result = func(*args, **kwargs)
    elapsed = time.perf_counter() - t0
    peak = tracemalloc.get_traced_memory()[1]
    tracemalloc.stop()
    return elapsed, peak, result


class SequenceDS(ABC):

    def __init__(self):
        self._items: List[Any] | deque[Any] = []

    def add(self, item: Any):
        self._items.append(item)

    def get_pos(self, index: int):
        return self._items[index] if 0 <= index < len(self._items) else None

    @abstractmethod
    def remove(self): pass


class Stack(SequenceDS):               # LIFO
    def remove(self):
        return self._items.pop() if self._items else None


class Queue(SequenceDS):               # FIFO
    def __init__(self):
        self._items: deque[Any] = deque()

    def remove(self):
        return self._items.popleft() if self._items else None


class HashTable:
    def __init__(self):
        self._table: Dict[int, Any] = {}

    def add(self, key: int, value: Any):
        self._table[key] = value

    def get_pos(self, key: int):
        return self._table.get(key)

    def remove(self, key: int):
        return self._table.pop(key, None)


def bulk_insert(ds, items: List[str]) -> Tuple[float, int]:
    if isinstance(ds, HashTable):
        return benchmark(lambda: [ds.add(i, val) for i, val in enumerate(items)])[:2]
    return benchmark(lambda: [ds.add(val) for val in items])[:2]


def main():
    listing_path = "lista_completa.txt"
    files = read_listing(listing_path)
    last_index = len(files) - 1
    indexes = [0, 99, 999, 4999, last_index]
    indexes = [i for i in indexes if 0 <= i <= last_index]

    structures = {
        "HashTable": HashTable(),
        "Stack": Stack(),
        "Queue": Queue(),
    }

    for name, ds in structures.items():
        ins_time, ins_mem = bulk_insert(ds, files)
        access_time_total = 0.0
        accessed: Dict[int, Any] = {}
        for idx in indexes:
            t, _, val = benchmark(ds.get_pos, idx)
            access_time_total += t
            accessed[idx + 1] = val

        if isinstance(ds, HashTable):
            add_t, add_m, _ = benchmark(ds.add, -1, "nova_entrada.txt")
            rem_t, rem_m, _ = benchmark(ds.remove, -1)
        else:
            add_t, add_m, _ = benchmark(ds.add, "nova_entrada.txt")
            rem_t, rem_m, _ = benchmark(ds.remove)

        print(f"\n--- {name} ---")
        print(f"Inserção   : {ins_time:.6f}s | {ins_mem:,} B")
        print(f"Acesso total  : {access_time_total:.6f}s")
        print(f"Adição única    : {add_t:.6f}s | {add_m:,} B")
        print(f"Remoção única : {rem_t:.6f}s | {rem_m:,} B")
        for idx, val in accessed.items():
            print(f"Posição {idx:<5}: {val}")


if __name__ == "__main__":
    main()
