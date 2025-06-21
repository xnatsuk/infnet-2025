namespace AppTurismo.Services;

public class LogService
{
    public static Action<string> LogDelegate {get;set;}
    private static readonly List<string> MemoryLogs = new();
    public static List<string> GetMemoryLogs() => [..MemoryLogs]; // collection expression

    static LogService()
    {
        LogDelegate = LogToConsole;
        LogDelegate += LogToFile;
        LogDelegate += LogToMemory;
    }

    public static void LogToConsole(string message) =>
        Console.WriteLine($"[CONSOLE] {DateTime.Now:u} - {message}");

    public static void LogToFile(string message)
    {
        string path = Path.Combine("wwwroot", "files", "log.txt");
        string entry = $"[FILE] {DateTime.Now:u} - {message}";

        Directory.CreateDirectory(Path.GetDirectoryName(path) ?? throw new InvalidOperationException());
        File.AppendAllText(path, entry);
    }

    public static void LogToMemory(string message)
    {
        string entry = $"[MEMORY] {DateTime.Now:u} - {message}";
        MemoryLogs.Add(entry);

        if(MemoryLogs.Count > 100) MemoryLogs.RemoveAt(0);
    }
}
