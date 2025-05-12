namespace at;

public class Calculadora
{
    public static void Calcular()
    {
        // Solicita e valida os números

        Console.WriteLine("Digite o primeiro número:");
        if (!double.TryParse(Console.ReadLine(), out double numero1))
            Console.WriteLine("Valor inválido. Digite um número válido:");

        Console.WriteLine("Digite o segundo número:");
        if (!double.TryParse(Console.ReadLine(), out double numero2))
            Console.WriteLine("Valor inválido. Digite um número válido:");

        Console.WriteLine("\nEscolha a operação:");
        Console.WriteLine("1 - Soma");
        Console.WriteLine("2 - Subtração");
        Console.WriteLine("3 - Multiplicação");
        Console.WriteLine("4 - Divisão");

        // Solicita a operação
        if (!int.TryParse(Console.ReadLine(), out int operacao))
            Console.WriteLine("Valor inválido");

        // Realiza o cálculo
        double resultado = operacao switch
        {
            1 => numero1 + numero2,
            2 => numero1 - numero2,
            3 => numero1 * numero2,
            4 when numero2 != 0 => numero1 / numero2,
            4 when numero2 == 0 => throw new DivideByZeroException(),
            _ => throw new ArgumentOutOfRangeException()
        };

        Console.WriteLine("\nO resultado é: {0}", resultado);
    }
}