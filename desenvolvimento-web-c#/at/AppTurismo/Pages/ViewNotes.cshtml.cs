using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using AppTurismo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppTurismo.Pages;

public class ViewNotesModel : PageModel
{
    private readonly string _notesPath;

    public ViewNotesModel(IWebHostEnvironment env)
    {
        _notesPath = Path.Combine(env.WebRootPath, "files");
        Directory.CreateDirectory(_notesPath);
    }

    [BindProperty]
    [Required(ErrorMessage = "O título é obrigatório")]
    public string NoteTitle { get; set; } = string.Empty;

    [BindProperty]
    [Required(ErrorMessage = "O conteúdo é obrigatório")]
    public string NoteContent { get; set; } = string.Empty;

    public List<string> AvailableNotes { get; set; } = new();
    public string? SelectedNoteContent { get; set; }

    public void OnGet(string? fileName = null)
    {
        LoadAvailableNotes();

        if (!string.IsNullOrEmpty(fileName))
        {
            string filePath = Path.Combine(_notesPath, fileName);
            if (System.IO.File.Exists(filePath))
                SelectedNoteContent = System.IO.File.ReadAllText(filePath);
        }
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            LoadAvailableNotes();
            return Page();
        }

        string fileName = string.Format("{0:M}_{1}.txt", DateTime.Now, "Nota");
        string filePath = Path.Combine(_notesPath, fileName);


        System.IO.File.WriteAllText(filePath, NoteContent);

        NoteTitle = string.Empty;
        NoteContent = string.Empty;

        return RedirectToPage();
    }

    private void LoadAvailableNotes()
    {
        AvailableNotes = Directory.GetFiles(_notesPath, "*.txt")
            .Select(Path.GetFileName)
            .Where(f => f != null)
            .Cast<string>()
            .OrderByDescending(f => f)
            .ToList();
    }
}
