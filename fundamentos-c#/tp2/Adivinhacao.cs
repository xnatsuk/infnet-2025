namespace tp2;

public static class Adivinhacao
{
    public static void Jogar()
    {
        int numeroAleatorio = new Random().Next(1, 100);

        while (true)
        {
            Console.Write("Digite um valor de 1 a 100: ");
            if (!int.TryParse(Console.ReadLine(), out int valor)) Console.WriteLine("Valor inválido.");

            if (valor == numeroAleatorio) break;
            Console.WriteLine(valor > numeroAleatorio ? "Menor" : "Maior");
        }

        Console.WriteLine("Parabéns!");
    }
}