namespace tp2;

public static class DiferencaData
{
    public static void Calcular()
    {
        Console.WriteLine("Digite a data de início (yyyy/mm/dd): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime primeiraData)) Console.WriteLine("Formato inválido.");
        Console.WriteLine("Digite outra data (yyyy/mm/dd): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime segundaData)) Console.WriteLine("Formato inválido.");

        if (primeiraData > segundaData)
            // Inverte as datas
            (primeiraData, segundaData) = (segundaData, primeiraData);

        TimeSpan totalDias = segundaData - primeiraData;
        int meses = 0;
        int anos = 0;

        while (primeiraData.AddYears(1) < segundaData)
        {
            primeiraData = primeiraData.AddYears(1);
            anos++;
        }

        while (primeiraData.AddMonths(1) < segundaData)
        {
            primeiraData = primeiraData.AddMonths(1);
            meses++;
        }

        int dias = (segundaData - primeiraData).Days;

        Console.WriteLine("Total de dias: {0}." +
                          "\n{1} anos, {2} meses, {3} dias.", totalDias.Days, anos, meses, dias);
    }
}