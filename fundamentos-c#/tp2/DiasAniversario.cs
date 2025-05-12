namespace tp2;

public static class DiasAniversario
{
    public static void Calcular()
    {
        Console.WriteLine("Data de Aniversário (yyyy/mm/dd):");

        if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataNascimento)) Console.WriteLine("Formato inválido.");
        DateTime atual = DateTime.Now;
        DateTime aniversario = new(
            atual.Year,
            dataNascimento.Month,
            dataNascimento.Day
        );

        if (aniversario < atual) aniversario = aniversario.AddYears(1);

        int contagemDias = (aniversario - atual).Days;
        if (contagemDias == 0) Console.WriteLine("Hoje é seu aniversário!");
        Console.WriteLine("Faltam {0} dias até seu aniversário.", contagemDias);
    }
}