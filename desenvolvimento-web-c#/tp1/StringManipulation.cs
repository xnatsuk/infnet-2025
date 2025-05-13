namespace tp1;

public static class StringManipulation
{
    public static void Manipulate()
    {
        try
        {
            Console.Write("Digite seu nome: ");
            string firstName = Console.ReadLine() ?? throw new InvalidOperationException();

            Console.Write("Digite seu sobrenome: ");
            string lastName = Console.ReadLine() ?? throw new InvalidOperationException();

            // Definindo os delegates individuais
            Func<string, string, string> concatenateNames = (first, last) => $"{first} {last}";
            Func<string, string> toUpperCase = text => text.ToUpper();
            Func<string, string> removeWhitespace = text => text.Replace(" ", "");

            static Func<string, string> TransformName(Func<string, string> f, Func<string, string> g) =>
                x => g(f(x));

            var result = new Func<string, string, string>((a, b) =>
            {
                string initialName = concatenateNames(a, b);
                var transformedName = TransformName(toUpperCase, removeWhitespace)(initialName);
                return transformedName;
            });

            Console.WriteLine(result(firstName, lastName));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro: {0}", ex.Message);
        }
    }
}
