namespace tp2;

public static class SalarioLiquido
{
    public static void Calcular()
    {
        Console.WriteLine("Salário Bruto: ");
        if (!double.TryParse(Console.ReadLine(), out double salarioBruto)) Console.WriteLine("Valor inválido");
        double taxa = salarioBruto switch
        {
            < 5000 => 0,
            < 7500 => salarioBruto * 0.08,  // 8%
            < 13000 => salarioBruto * 0.12, // 12%
            < 20000 => salarioBruto * 0.16, // 16%
            _ => salarioBruto * 0.20        //20%
        };

        double liquido = salarioBruto - taxa;

        Console.WriteLine("Liquido: R$ {0:F2} \nBruto: R$ {1:F2}, \nDesconto: R$ {2:F2}", liquido, salarioBruto, taxa);
    }
}