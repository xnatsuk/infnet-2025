namespace tp2;

public static class CalculoIdade
{
    public static void Calcular()
    {
        Console.WriteLine("Digite sua data de nascimento (yyyy/mm/dd): ");

        if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataNascimento)) Console.WriteLine("Formato inválido.");

        DateTime atual = DateTime.Now;
        int dias = atual.Day - dataNascimento.Day;
        int meses = atual.Month - dataNascimento.Month;
        int anos = atual.Year - dataNascimento.Year;

        if (dias < 0)
        {
            dias += DateTime.DaysInMonth(atual.Year, atual.Month);
            if (meses < 0)
            {
                meses += 12;
                anos--;
            }
        }

        if (meses < 0)
        {
            meses += 12;
            anos--;
        }

        Console.WriteLine(@"{0} anos, {1} meses e {2} dias", anos, meses, dias);
    }
}