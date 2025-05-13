namespace tp1;

public class Logger
{
    // multicast delegate
    private Action<string> LogHandler { get; set; }

    private Logger()
    {
        LogHandler += LogToConsole;
        LogHandler += LogToFile;
        LogHandler += LogToDatabase;
    }

    public static void Start()
    {
        Logger logger = new Logger();

        Console.WriteLine("== Sistema de Log ==");
        // invoca o delegate multicast
        logger.Log("Sistema iniciado com sucesso.");

        logger.LogHandler -= logger.LogToFile;
        logger.Log("Este log não irá para o arquivo");

        logger.LogHandler = null;
        logger.Log("Este log não será registrada.");
    }


    private void Log(string message)
    {
        LogHandler?.Invoke(message);
    }

    private void LogToConsole(string message) =>
        Console.WriteLine($"[CONSOLE] {DateTime.Now}: {message}");


    private void LogToFile(string message) =>
        // Simulação de gravação em arquivo
        Console.WriteLine($"[ARQUIVO] {DateTime.Now}: {message}");


    private void LogToDatabase(string message) =>
        // Simulação de gravação em banco de dados
        Console.WriteLine($"[BANCO DE DADOS] {DateTime.Now}: {message}");
}
