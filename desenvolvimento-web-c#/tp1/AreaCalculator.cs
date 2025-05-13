namespace tp1;

public static class AreaCalculator
{
    public static void CalculateArea()
    {
        Func<double, double, double> calculate = (width, height) =>
            width * height;

        try
        {
            Console.Write("Valor da largura: ");
            if (!double.TryParse(Console.ReadLine(), out double width)) ;

            Console.Write("Valor da altura: ");
            if (!double.TryParse(Console.ReadLine(), out double height)) ;

            double area = calculate(width, height);
            Console.WriteLine("\nA área é {0}", area);
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Insira apenas valores númericos");
        }
    }
}
