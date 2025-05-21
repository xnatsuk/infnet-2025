namespace tp2;

public static class ConverterTemperatura
{
    public static void Converter()
    {
        Console.WriteLine("Temperatura em Celsius: ");
        if (!double.TryParse(Console.ReadLine(), out double c)) Console.WriteLine("Entrada invalida.");
        double f = c * 9 / 5 + 32;
        double k = c + 273.15;

        Console.WriteLine("Temperatura em Fahrenheit: {0} \nTemperatura em Kelvin: {1}", f, k);
    }
}