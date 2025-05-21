namespace tp2;

public static class Tabuada
{
    public static void Calcular()
    {
        Console.WriteLine("Número da Tabuada: ");
        if (!int.TryParse(Console.ReadLine(), out int numero)) Console.WriteLine("Número inválido");

        for (int i = 1; i <= 10; i++)
        {
            int resultado = numero * i;
            Console.WriteLine("{0} x {1} = {2}", numero, i, resultado);
        }
    }
}