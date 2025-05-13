namespace tp1;

public static class Program
{
    private static void Main(string[] args)
    {
        // Run(DiscountCalculator.Calculate);
        // Run(MultilanguageAction.Welcome);
        // Run(AreaCalculator.CalculateArea);
        // Run(TempMonitor.Monitor);
        // Run(DownloadEventNotifier.Download);
        Run(Logger.Start);
        // Run(StringManipulation.Manipulate);
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
            Console.WriteLine("[Erro ao executar o exercício] \n{0}", e.Message);
        }
    }
}
