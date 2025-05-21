namespace tp2;

public static class Timer
{
    public static void Contar()
    {
        Console.WriteLine("Digite um número para iniciar a contagem: ");
        if (!int.TryParse(Console.ReadLine(), out int valor) && valor >= 0) Console.WriteLine("Valor inválido");

        for (int i = valor; i >= 0; i--)
            if (i > 0) Console.Write($"{i}, ");
            else Console.Write(i); // caso seja o ultimo numero.
    }
}