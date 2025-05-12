namespace at;

public class Cifrador
{
    public static void CifradorNome()
    {
        Console.WriteLine("Digite seu nome completo:");
        string nome = Console.ReadLine() ?? throw new InvalidOperationException();

        string nomeCifrado = CifrarNome(nome);

        Console.WriteLine("Nome cifrado: {0}", nomeCifrado);
    }

    private static string CifrarNome(string nome)
    {
        // Converte string em array
        char[] caracteres = nome.ToCharArray();

        // Para cada caractere no array
        for (int i = 0; i < caracteres.Length; i++)
            // Ignora o que não é letra
            if (char.IsLetter(caracteres[i]))
                // Desloca a letra 2 posições para frente no alfabeto
                caracteres[i] = (char)(caracteres[i] + 2);
        // Converte de volta para string
        return new string(caracteres);
    }
}