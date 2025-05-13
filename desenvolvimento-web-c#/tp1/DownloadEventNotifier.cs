using System.ComponentModel;

namespace tp1;

public static class DownloadEventNotifier
{
    public static void Download()
    {
        DownloadManager downloadManager = new DownloadManager();
        downloadManager.DownloadCompleted += OnDownloadCompleted;

        try
        {
            Console.WriteLine("==== Download Manager ====");
            Console.WriteLine("Informe o nome do arquivo para download: ");
            string fileName = Console.ReadLine() ?? "download.zip";

            Console.WriteLine("Informe o tamanho do arquivo: ");
            if (!int.TryParse(Console.ReadLine(), out int fileSize)) fileSize = 1024;

            downloadManager.StartDownload(fileName, fileSize);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro: {0}", ex.Message);
        }
    }

    private static void OnDownloadCompleted(object? sender, DownloadEventArgs eventArgs)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n[{0:HH:mm:ss}] O arquivo {1} ({2} KB) foi baixado.",
                          eventArgs.CompletionDate, eventArgs.FileName, eventArgs.FileSize);
        Console.ResetColor();
    }
}

public class DownloadEventArgs(string fileName, long fileSize) : EventArgs
{
    public string FileName { get; } = fileName;
    public DateTime CompletionDate { get; } = DateTime.Now;
    public long FileSize { get; } = fileSize;
}

public class DownloadManager
{
    public event EventHandler<DownloadEventArgs>? DownloadCompleted;

    public void StartDownload(string fileName, long fileSize)
    {
        Console.WriteLine("[Download Manager] Iniciando download de {0} ({1} KB)...", fileName, fileSize);
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine("Baixando: {0}%", i);
            Thread.Sleep(100);
        }

        Console.WriteLine("Download Concluído");
        // dispara o evento
        OnDownloadCompleted(fileName, fileSize);
    }

    protected virtual void OnDownloadCompleted(string fileName, long fileSize) =>
        DownloadCompleted?.Invoke(this, new DownloadEventArgs(fileName, fileSize));
}
