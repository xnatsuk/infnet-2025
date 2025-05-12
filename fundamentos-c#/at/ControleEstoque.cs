using System.Globalization;
using static System.Int32;


namespace at;

public class ControleEstoque
{
    public static void Testar()
    {
        string arquivo = "estoque.txt";
        bool run = true;

        while (run)
        {
            Console.Clear();
            Console.WriteLine("\n1 - Inserir Produto" +
                              "\n2 - Listar Produtos" +
                              "\n3 - Sair" +
                              "\nEscolha uma opção: ");
            Int32.TryParse(Console.ReadLine(), out int opcao);
            switch (opcao)
            {
                case 1: InserirProduto(arquivo); break;
                case 2: ListarProdutos(arquivo); break;
                case 3: run = false; break;
                default: Console.WriteLine("Opção Inválida"); break;
            }
        }
    }

    static void InserirProduto(string arquivoTexto)
    {
        int contador = 0;
        if (File.Exists(arquivoTexto)) contador = File.ReadAllLines(arquivoTexto).Length;
        if (contador >= 5)
        {
            Console.WriteLine("Limite de produto atingido.");
            return;
        }

        Console.WriteLine("Digite o nome do produto: ");
        string nome = Console.ReadLine() ?? throw new InvalidOperationException();

        Console.WriteLine("Quantidade em estoque: ");
        if (!int.TryParse(Console.ReadLine(), out int quantidadeProdutos))
            Console.WriteLine("Quantidade inválida.");

        Console.WriteLine("Preço por unidade (R$): ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal preco))
            Console.WriteLine("Valor inválido.");


        Produto produto = new Produto(nome, quantidadeProdutos, preco);
        try
        {
            using StreamWriter w = File.AppendText(arquivoTexto); // cria o arquivo caso não exista
            w.WriteLine("{0},{1},{2}\n",
                        produto.Nome,
                        produto.Quantidade,
                        produto.Preco.ToString(CultureInfo.InvariantCulture.NumberFormat)); // decimal com '.'

            Console.WriteLine("Produto Cadastrado com sucesso.");
        }
        catch (Exception err)
        {
            Console.WriteLine("Erro ao cadastrar o produto. {0}", err.Message);
        }

        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static void ListarProdutos(string arquivoTexto)
    {
        Console.WriteLine("--- Produtos em Estoque ---\n");
        if (!File.Exists(arquivoTexto)) Console.WriteLine("Nenhum produto cadastrado.");

        try
        {
            string[] linhas = File.ReadAllLines(arquivoTexto);
            if (linhas.Length == 0) Console.WriteLine("Nenhum produto cadastrado.");

            foreach (string i in linhas)
            {
                string[] dados = i.Split(',');
                string produtoNome = dados[0];
                int quantidade = int.Parse(dados[1]);
                decimal produtoPreco =
                    decimal.Parse(dados[2], CultureInfo.CreateSpecificCulture("en-US").NumberFormat); // decimal com ','

                Console.WriteLine("Produto: {0} | Quantidade: {1} | Preço: R$ {2}",
                                  produtoNome,
                                  quantidade,
                                  produtoPreco);
            }
        }
        catch (Exception err)
        {
            Console.WriteLine("Erro ao listar os produtos. {0}", err.Message);
        }

        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}

class Produto
{
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public decimal Preco { get; set; }

    public Produto(string nome, int quantidade, decimal preco)
    {
        Nome = nome;
        Quantidade = quantidade;
        Preco = preco;
    }
}