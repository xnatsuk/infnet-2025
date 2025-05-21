using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace tp2.Pages.CityManager;

public class SaveNoteModel : PageModel
{
    public class InputModel
    {
        [Required(ErrorMessage = "O conteúdo não pode ser vazio.")]
        [Display(Name = "Conteúdo")]
        public string? Content { get; set; }
    }

    [BindProperty]
    public InputModel? Input { get; set; }
    public string? SavedFile { get; set; }

    public void OnGet() => Input = new InputModel();

    public void OnPost()
    {
        if (!ModelState.IsValid) return;
        try
        {
           string dir = Path.Combine("wwwroot", "files");
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

           string timestamp = DateTime.Now.ToString("ddMMyyyyHHmmss");
           string fileName = $"note-{timestamp}.txt";
           string filePath = Path.Combine(dir, fileName);

            System.IO.File.WriteAllText(filePath, Input?.Content);
            SavedFile = $"/files/{fileName}";
            Input = new InputModel();
        }
        catch (Exception e)
        {
            ModelState.AddModelError(string.Empty, $"Erro ao salvar o arquivo: {e.Message}");
        }
    }
}
