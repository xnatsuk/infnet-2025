namespace tp2;

public static class CalculoImc
{
    public static void Calcular()
    {
        Console.WriteLine("Digite sua altura em metros: ");
        if (!double.TryParse(Console.ReadLine(), out double altura)) Console.WriteLine("Altura inválida.");
        Console.WriteLine("Seu peso em kg: ");
        if (!double.TryParse(Console.ReadLine(), out double peso)) Console.WriteLine("Peso inválido.");

        double imc = peso / (altura * altura);

        string faixa = imc switch // switch expression, achei bonito
        {
            < 18.5 => "Abaixo do Peso",
            < 25 => "Peso Normal",
            < 30 => "Sobrepeso",
            _ => "Obesidade"
        };

        Console.WriteLine("Seu IMC está na faixa de: {0}", faixa);
    }
}