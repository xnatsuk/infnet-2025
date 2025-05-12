namespace at;

public class DataFormatura
{
    public static void Calcular()
    {
        // data prevista de formatura
        DateTime dataFormatura = new(2025, 12, 15);
        Console.WriteLine("Digite a data atual (dd/MM/yyyy):");

        if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataAtual))
            throw new Exception("Data inválida. Digite no formato dd/MM/yyyy:");

        // verifica se a data informada é no futuro
        if (dataAtual > DateTime.Today)
            throw new Exception("Erro: A data informada não pode ser no futuro!");

        // verifica se a data de formatura já passou
        if (dataFormatura < dataAtual)
        {
            Console.WriteLine("Parabéns! Você já deveria estar formado!");
            return;
        }

        // diferença entre as datas em dias
        int totalDias = (dataFormatura - dataAtual).Days;
        int anos = totalDias / 365;
        int diasRestantes = totalDias % 365;
        int meses = diasRestantes / 30;
        int dias = diasRestantes % 30;

        if (anos == 0 && meses < 6)
        {
            Console.WriteLine("A reta final chegou! Prepare-se para a formatura!");
            return;
        }

        Console.WriteLine(anos > 0
                              ? "Faltam {0} anos, {1} meses e {2} dias para sua formatura!"
                              : "Faltam {1} meses e {2} dias para sua formatura!",
                          anos, meses, dias);
    }
}