namespace at;

public class DiasAniversario
{
    public static void Contar()
    {
        Console.WriteLine("Data de Aniversário:");

        if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataNascimento)) Console.WriteLine("Formato inválido.");
        DateTime atual = DateTime.Now;
        DateTime aniversario = new(
            atual.Year,
            dataNascimento.Month,
            dataNascimento.Day
        );

        if (aniversario < atual) aniversario = aniversario.AddYears(1);

        int contagemDias = (aniversario - atual).Days;
        if (contagemDias < 7) Console.WriteLine("Seu aniversario está chegando!");
        Console.WriteLine("Faltam {0} dias até seu aniversário.", contagemDias);
    }
}