namespace tp1;

public static class MultilanguageAction
{
    public static void Welcome()
    {
        Console.WriteLine("Escolha um idioma: " +
                          "\n1 - Português" +
                          "\n2 - Inglês" +
                          "\n3 - Espanhol");
        if (!int.TryParse(Console.ReadLine(), out int language)) throw new FormatException();
        Action<string> mensagem = language switch
        {
            1 => WelcomePt,
            2 => WelcomeEn,
            3 => WelcomeEs,
            _ => throw new FormatException()
        };

        Console.WriteLine("\nDigite o seu nome: ");
        mensagem(Console.ReadLine() ?? throw new FormatException());
    }

    private static void WelcomePt(string name) =>
        Console.WriteLine("Bem-vindo(a) {0}!", name);


    private static void WelcomeEn(string name) =>
        Console.WriteLine("Welcome {0}!", name);


    private static void WelcomeEs(string name) =>
        Console.WriteLine("Bienvenido(a) {0}!", name);
}
