public class Main {
    public static void main(String[] args) {
        RedBlackTreeInt tree = new RedBlackTreeInt();

        int[] valoresInserir = {41, 38, 31, 12, 19, 8};
        for (int valor : valoresInserir) {
            tree.insert(valor);
            System.out.println("Após inserir " + valor + ":");
            System.out.print("Inorder: ");
            tree.inorder();
        }

        System.out.println("\n--- BLACK HEIGHT ---");
        System.out.println("Black height da árvore: " + tree.blackHeight());
        System.out.println("Black height do nó 31: " + tree.blackHeight(31));
        System.out.println("Black height do nó 38: " + tree.blackHeight(38));

        System.out.println("\n--- REMOÇÃO ---");
        int[] valoresRemover = {12, 19};
        for (int valor : valoresRemover) {
            tree.delete(valor);
            System.out.print("Após remover " + valor + ": ");
            tree.inorder();
        }

        System.out.println("Black height final: " + tree.blackHeight());


        // Parte B — Árvore B
        DivideNo.No pai = new DivideNo.No(false);
        pai.n = 0;

        // nó cheio (folha) com 3 chaves: [5, 10, 15]
        DivideNo.No cheio = new DivideNo.No(true);
        cheio.n = 3;
        cheio.chaves[0] = 5;
        cheio.chaves[1] = 10;
        cheio.chaves[2] = 15;
        // Pai aponta para o nó cheio
        pai.filhos[0] = cheio;

        System.out.println("\n--- ANTES DO SPLIT ---");
        DivideNo.imprimirNo("Pai", pai);
        DivideNo.imprimirNo("Cheio", cheio);

        // split
        DivideNo divisor = new DivideNo();
        divisor.divideNo(pai, 0, cheio);

        System.out.println("\n--- DEPOIS DO SPLIT ---");
        DivideNo.imprimirNo("Pai", pai);
        DivideNo.imprimirNo("Filho esquerdo (cheio)", pai.filhos[0]);
        DivideNo.imprimirNo("Filho direito (novo)", pai.filhos[1]);

    }
}
