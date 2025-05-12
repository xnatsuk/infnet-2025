namespace tp3;

public class Program
{
    public static void Main(string[] args)
    {
        /*// Object Initializer
         Ingresso ingresso = new Ingresso()
            {
                nomeDoShow = "Emopallooza",
                preco = 500,
                quantidadeDisponivel = 1248
            };

            ingresso.ExibirInformacoes();

            ingresso.AlterarPreco(490);
            ingresso.AlterarQuantidade(925);

            Console.WriteLine("\nInformações atualizadas:");
            ingresso.ExibirInformacoes();

            ingresso.SetNomeDoShow("Show de Fim de Ano");
            ingresso.SetPreco(120);
            ingresso.SetQuantidadeDisponivel(5000);

            Console.WriteLine("\nNome do Show: {0}\nPreço: R$ {1:f}\nDisponíveis: {2}",
                              ingresso.GetNomeDoShow(),
                              ingresso.GetPreco(),
                              ingresso.GetQuantidadeDisponivel());*/
        //com construtor
        Ingresso lolla = new Ingresso("Lollapalooza", 450, 2000);
        lolla.ExibirInformacoes();

        //Teste Matricula

        // Object Initializer
        Matricula maria = new Matricula
        {
            nomeDoAluno = "Maria Soares",
            curso = "Engenharia de Software",
            numeroMatricula = 12345,
            situacao = "Ativa",
            dataInicial = "01/07/2023"
        };

        maria.ExibirInformacoes();

        Console.WriteLine("\nTrancar a matrícula:");
        maria.Trancar();
        maria.ExibirInformacoes();

        Console.WriteLine("\nReativar a matrícula:");
        maria.Reativar();
        maria.ExibirInformacoes();

        // Teste Figuras

        Circulo circulo = new Circulo
        {
            raio = 3.0
        };

        Esfera esfera = new Esfera
        {
            raio = 5.0
        };

        double areaCirculo = circulo.CalcularArea();
        double volumeEsfera = esfera.CalcularVolume();
        Console.WriteLine("\nÁrea circulo: {0:f} \nVolume Esfera: {1:f}", areaCirculo, volumeEsfera);
    }
}