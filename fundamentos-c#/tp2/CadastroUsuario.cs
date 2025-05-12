namespace tp2;

public static class CadastroUsuario
{
    public static void Cadastrar()
    {
        Console.WriteLine("Digite seu nome: ");
        string nome = Console.ReadLine() ?? "";
        Console.WriteLine("Digite sua idade: ");
        int idade = int.Parse(Console.ReadLine() ?? "");
        Console.WriteLine("Digite seu email: ");
        string email = Console.ReadLine() ?? "";
        Console.WriteLine("Digite seu telefone: ");
        string telefone = Console.ReadLine() ?? "";

        Console.WriteLine("--- Usuário Cadastrado ---");
        Console.WriteLine("Nome: {0} \nIdade: {1} \nEmail: {2} \nTelefone: {3}", nome, idade, email, telefone);
    }
}