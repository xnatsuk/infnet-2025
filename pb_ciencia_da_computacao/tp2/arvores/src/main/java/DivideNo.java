public class DivideNo {
    public static void imprimirNo(String label, No no) {
        if (no == null) {
            System.out.println(label + ": null");
            return;
        }

        System.out.print(label + ": [");
        for (int i = 0; i < no.n; i++) {
            System.out.print(no.chaves[i]);
            if (i < no.n - 1) System.out.print(", ");
        }
        System.out.print("]");
        System.out.println(no.folha ? " (folha)" : " (interno)");
    }

    public void divideNo(No pai, int i, No cheio) {
        No novoNo = new No(cheio.folha);
        novoNo.n = 1;  // t-1 = 1 (receberá 1 chave)
        novoNo.chaves[0] = cheio.chaves[2];

        if (!cheio.folha) {
            novoNo.filhos[0] = cheio.filhos[2];
            novoNo.filhos[1] = cheio.filhos[3];
        }

        cheio.n = 1;  // t-1 = 1 (ficará apenas com a primeira chave)

        for (int j = pai.n; j > i; j--) {
            pai.filhos[j + 1] = pai.filhos[j];
        }

        pai.filhos[i + 1] = novoNo;

        for (int j = pai.n - 1; j >= i; j--) {
            pai.chaves[j + 1] = pai.chaves[j];
        }
        //  promover a chave mediana (índice 1) para o pai
        pai.chaves[i] = cheio.chaves[1];
        pai.n++;
    }

    static class No {
        int[] chaves;      // Array de chaves [máximo 3 para t=2]
        int n;
        No[] filhos;       // Array de filhos [máximo 4 para t=2]
        boolean folha;     // true se é folha, false se é nó interno

        public No(boolean folha) {
            this.chaves = new int[3];      // 2t-1 = 3
            this.filhos = new No[4];       // 2t = 4
            this.n = 0;
            this.folha = folha;
        }
    }
}
