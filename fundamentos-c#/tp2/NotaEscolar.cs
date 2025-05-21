namespace tp2;

public static class NotaEscolar
{
    public static void Calcular()
    {
        Console.WriteLine("Sua nota: ");
        if (!double.TryParse(Console.ReadLine(), out double nota)) Console.WriteLine("Valor inválido.");
        string resultado = nota switch
        {
            < 5 => "Insuficiente",
            < 7 => "Regular",
            < 9 => "Bom",
            _ => "Excelente"
        };

        Console.WriteLine(resultado);
    }
}