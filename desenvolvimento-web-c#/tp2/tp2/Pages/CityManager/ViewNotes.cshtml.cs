using Microsoft.AspNetCore.Mvc.RazorPages;

namespace tp2.Pages.CityManager;

public class ViewNotesModel : PageModel
{
    public List<FileInfo> Files { get; set; } = [];
    public string? SelectedFile { get; set; }
    public string? FileContent { get; set; }

    public void OnGet(string fileName)
    {
        string dir = Path.Combine("wwwroot", "files");
        if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

        DirectoryInfo dirInfo = new DirectoryInfo(dir);
        Files = [.. dirInfo.GetFiles().OrderByDescending(f=>f.LastWriteTime)];
        if (string.IsNullOrEmpty(fileName)) return;

        SelectedFile = fileName;
        string path = Path.Combine(dir, fileName);
        FileContent = System.IO.File.ReadAllText(path);
    }
}
