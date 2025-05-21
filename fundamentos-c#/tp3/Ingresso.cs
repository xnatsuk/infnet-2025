namespace tp3;

public class Ingresso
{
    public string nomeDoShow;
    public double preco;
    public int quantidadeDisponivel;

    public Ingresso(string nomeDoShow, double preco, int quantidadeDisponivel)
    {
        this.nomeDoShow = nomeDoShow;
        this.preco = preco;
        this.quantidadeDisponivel = quantidadeDisponivel;
    }

    public string GetNomeDoShow()
    {
        return nomeDoShow;
    }

    public double GetPreco()
    {
        return preco;
    }

    public int GetQuantidadeDisponivel()
    {
        return quantidadeDisponivel;
    }

    // Setters
    public void SetNomeDoShow(string novoNome)
    {
        nomeDoShow = novoNome;
    }

    public void SetPreco(double novoPreco)
    {
        preco = novoPreco;
    }

    public void SetQuantidadeDisponivel(int novaQtd)
    {
        quantidadeDisponivel = novaQtd;
    }

    public void AlterarPreco(double novoPreco)
    {
        preco = novoPreco;
    }

    public void AlterarQuantidade(int novaQuantidade)
    {
        quantidadeDisponivel = novaQuantidade;
    }

    public void ExibirInformacoes()
    {
        Console.WriteLine("Show: {0} \nPreço: R$ {1:f} \nDisponíveis: {2}\n", nomeDoShow, preco, quantidadeDisponivel);
    }
}