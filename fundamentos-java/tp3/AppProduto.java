class AppProduto {
    public static void main(String[] args) {
        /* Sem construtor
        Produto arroz = new Produto();
        arroz.nome = "Arroz";
        arroz.preco = 11.99;
        arroz.quantidadeEmEstoque = 12;

        System.out.println("Informações iniciais:");
        arroz.exibirInformacoes();

        arroz.alterarPreco(10.39);
        arroz.alterarQuantidade(45);

        System.out.println("\nInformações atualizadas:");
        arroz.exibirInformacoes();*/

        // Com construtor
        Produto macarrao = new Produto("Macarrão", 13.99, 12);
        
        System.out.println("Nome: " + macarrao.getNome());
        System.out.println("Preço: R$ " + macarrao.getPreco());
        System.out.println("Quantidade em estoque: " + macarrao.getQuantidadeEmEstoque());

        macarrao.setNome("Macarrão Yakisoba");
        macarrao.setPreco(27.99);
        macarrao.setQuantidadeEmEstoque(10);

        System.out.println("\nNovos valores:");
        System.out.println("Nome: " + macarrao.getNome());
        System.out.println("Preço: R$ " + macarrao.getPreco());
        System.out.println("Quantidade em estoque: " + macarrao.getQuantidadeEmEstoque());
    }
}

class Produto {
    String nome;
    double preco;
    int quantidadeEmEstoque;

    Produto(String nome, double preco, int quantidadeEmEstoque) {
        this.nome = nome;
        this.preco = preco;
        this.quantidadeEmEstoque = quantidadeEmEstoque;
    }

    String getNome() {
        return nome;
    }

    void setNome(String nome) {
        this.nome = nome;
    }

    double getPreco() {
        return preco;
    }

    void setPreco(double preco) {
        this.preco = preco;
    }

    int getQuantidadeEmEstoque() {
        return quantidadeEmEstoque;
    }

    void setQuantidadeEmEstoque(int quantidadeEmEstoque) {
        this.quantidadeEmEstoque = quantidadeEmEstoque;
    }

    void alterarPreco(double preco) {
        this.preco = preco;
    }

    void alterarQuantidade(int quantidadeEmEstoque) {
        this.quantidadeEmEstoque = quantidadeEmEstoque;
    }

    void exibirInformacoes() {
        System.out.println("Nome: " + nome);
        System.out.println("Preço: R$ " + preco);
        System.out.println("Quantidade em estoque: " + quantidadeEmEstoque);
    }
}
