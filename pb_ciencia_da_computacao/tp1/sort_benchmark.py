
# from __future__ import annotations
import time
from pathlib import Path
from typing import List, Callable, Dict


def read_listing(path: str | Path) -> List[str]:
    with open(path, encoding="utf-8") as file:
        return [line.split("\t")[0].strip() for line in file if line.strip()]


def bubble_sort(data: List[str]):
    n = len(data)
    for i in range(n):
        swapped = False
        for j in range(n - i - 1):
            if data[j] > data[j + 1]:
                data[j], data[j + 1] = data[j + 1], data[j]
                swapped = True
        if not swapped:
            break


def selection_sort(data: List[str]):
    n = len(data)
    for i in range(n):
        min_idx = min(range(i, n), key=data.__getitem__)
        data[i], data[min_idx] = data[min_idx], data[i]


def insertion_sort(data: List[str]):
    for i in range(1, len(data)):
        key = data[i]
        j = i - 1
        while j >= 0 and data[j] > key:
            data[j + 1] = data[j]
            j -= 1
        data[j + 1] = key


def benchmark(algorithm: Callable[[List[str]], None],
                   sequence: List[str]) -> float:
    data_copy = sequence.copy()
    start = time.perf_counter()
    algorithm(data_copy)
    return time.perf_counter() - start


def main():
    listing_path = "lista_completa.txt"
    items = read_listing(listing_path)

    algorithms: Dict[str, Callable[[List[str]], None]] = {
        "Bubble Sort": bubble_sort,
        "Selection Sort": selection_sort,
        "Insertion Sort": insertion_sort,
    }

    print(f"Total: {len(items)}\n")
    for name, algo in algorithms.items():
        elapsed = benchmark(algo, items)
        print(f"{name:<15}: {elapsed:.6f}s") # formatação bonitinha


if __name__ == "__main__":
    main()
