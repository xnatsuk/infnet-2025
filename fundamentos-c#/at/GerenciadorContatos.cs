namespace at;

public class GerenciadorContatos
{
    public static void Testar()
    {
        string arquivo = "contatos.txt";
        bool run = true;

        while (run)
        {
            Console.Clear();
            Console.WriteLine("\n1 - Adicionar novo contato" +
                              "\n2 - Listar contatos cadastrados" +
                              "\n3 - Sair" +
                              "\nEscolha uma opção: ");
            Int32.TryParse(Console.ReadLine(), out int opcao);
            switch (opcao)
            {
                case 1: AdicionarContato(arquivo); break;
                case 2: ListarContatos(arquivo); break;
                case 3: run = false; break;
                default: Console.WriteLine("Opção Inválida"); break;
            }
        }
    }

    static void AdicionarContato(string arquivo)
    {
        Console.WriteLine("Digite o nome do contato: ");
        string nome = Console.ReadLine() ?? throw new InvalidOperationException();

        Console.WriteLine("Telefone: ");
        string tel = Console.ReadLine() ?? throw new InvalidOperationException();

        Console.WriteLine("Email: ");
        string email = Console.ReadLine() ?? throw new InvalidOperationException();

        Contato novoContato = new Contato(nome, tel, email);

        try
        {
            using StreamWriter writer = File.AppendText(arquivo);
            writer.WriteLine(novoContato.FormatToFile());

            Console.WriteLine("\nContato cadastrado com sucesso!");
        }
        catch (Exception err)
        {
            Console.WriteLine("\nErro ao cadastrar o contato. {0}", err.Message);
        }

        Console.WriteLine("\nPressione qualquer tecla para continuar");
        Console.ReadKey();
    }

    static void ListarContatos(string arquivo)
    {
        List<Contato> contatos = CarregarContatos(arquivo);

        try
        {
            Console.WriteLine("\nEscolha o formato de exibição:" +
                              "\n1 - Markdown" +
                              "\n2 - Tabela" +
                              "\n3 - Texto Puro" +
                              "\nFormato: ");

            Int32.TryParse(Console.ReadLine(), out int opcao);
            ContatoFormatter formatter = opcao switch
            {
                1 => new MarkdownFormatter(),
                2 => new TabelaFormatter(),
                3 => new RawTextFormatter(),
                _ => throw new InvalidOperationException()
            };

            formatter.ExibirContatos(contatos);
        }
        catch (Exception err)
        {
            Console.WriteLine("\nErro ao listar os contatos {0}", err.Message);
        }


        Console.WriteLine("\nPressione qualquer tecla para continuar");
        Console.ReadKey();
    }

    static List<Contato> CarregarContatos(string arquivo)
    {
        if (!File.Exists(arquivo)) Console.WriteLine("Nenhum contato cadastrado.");

        List<Contato> contatos = new List<Contato>();

        try
        {
            using StreamReader reader = new StreamReader(arquivo);
            string[] linhas = File.ReadAllLines(arquivo);

            if (linhas.Length == 0) Console.WriteLine("Nenhum contato cadastrado.");

            foreach (string linha in linhas)
            {
                string[] dados = linha.Split(',');
                if (dados.Length == 3)
                {
                    string nome = dados[0];
                    string telefone = dados[1];
                    string email = dados[2];

                    contatos.Add(new Contato(nome, telefone, email));
                }
            }
        }
        catch (Exception err)
        {
            Console.WriteLine("\nErro ao ler os contatos. {0}", err.Message);
        }

        return contatos;
    }
}

class Contato
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }

    public Contato(string nome, string telefone, string email)
    {
        Nome = nome;
        Telefone = telefone;
        Email = email;
    }

    public string FormatStringOutput()
    {
        return $"Nome: {Nome} | Telefone: {Telefone} | Email: {Email}";
    }

    public string FormatToFile()
    {
        return $"{Nome},{Telefone},{Email}";
    }
}

abstract class ContatoFormatter
{
    public abstract void ExibirContatos(List<Contato> contatos);
}

class MarkdownFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("## Lista de Contatos");
        if (contatos.Count == 0) Console.WriteLine("Nenhum contato cadastrado.");

        foreach (Contato i in contatos)
        {
            Console.WriteLine("- **Nome:** {0}" +
                              "\n- 📞 Telefone: {1}" +
                              "\n- 📧 Email: {2}",
                              i.Nome, i.Telefone, i.Email);
        }
    }
}

class TabelaFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("\n----------------------------------------" +
                          "\n| Nome | Telefone | Email |" +
                          "\n----------------------------------------");
        if (contatos.Count == 0) Console.WriteLine("Nenhum contato cadastrado.");

        foreach (Contato i in contatos)
        {
            Console.WriteLine("| {0} | {1} | {2}", i.Nome, i.Telefone, i.Email);
        }

        Console.WriteLine("----------------------------------------");
    }
}

class RawTextFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        if (contatos.Count == 0) Console.WriteLine("Nenhum contato cadastrado.");

        foreach (Contato i in contatos)
        {
            Console.WriteLine("Nome: {0} | Telefone: {1} | Email:  {2}",
                              i.Nome, i.Telefone, i.Email);
        }
    }
}