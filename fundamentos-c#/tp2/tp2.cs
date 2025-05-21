namespace tp2;

public static class Tp2
{
    private static void Main(string[] args)
    {
        // Run(CalculoIdade.Calcular);
        // Run(DiasAniversario.Calcular);
        // Run(DiferencaData.Calcular);
        // Run(CadastroUsuario.Cadastrar);
        // Run(ConverterTemperatura.Converter);
        // Run(CalculoImc.Calcular);
        // Run(ParImpar.Verificar);
        // Run(NotaEscolar.Calcular);
        // Run(SalarioLiquido.Calcular);
        // Run(Timer.Contar);
        // Run(Tabuada.Calcular);
        // Run(Adivinhacao.Jogar);
    }

    private static void Run(Action action)
    {
        Console.Clear();

        try
        {
            action();
        }
        catch (Exception e)
        {
            Console.WriteLine($"\nErro ao executar o exercício: {e.Message}");
        }
    }
}