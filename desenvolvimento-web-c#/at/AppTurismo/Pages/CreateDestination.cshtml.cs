using AppTurismo.Data;
using AppTurismo.Models;
using AppTurismo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AppTurismo.Pages;

[Authorize]
public class CreateDestinationModel : PageModel
{
    private readonly AppTurismoContext _context;

    public CreateDestinationModel(AppTurismoContext context)
    {
        _context = context;
    }

    [BindProperty] public Destination Destination { get; set; } = new(name: "", country: "");

    [TempData] public string? SuccessMessage { get; set; }

    public List<Destination> ExistingDestinations { get; set; } = new();

    public async Task<IActionResult> OnGetAsync()
    {
        await LoadExistingDestinations();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await LoadExistingDestinations();

        if (!ModelState.IsValid)
            return Page();

        var destinationExists = await _context.Destinations
            .AnyAsync(d => d.Name!.ToLower() == Destination.Name!.ToLower() &&
                           d.Country!.ToLower() == Destination.Country!.ToLower());

        if (destinationExists)
        {
            ModelState.AddModelError("Destination.Name",
                string.Format("O destino já existe no sistema.", Destination.Name, Destination.Country));
            return Page();
        }

        try
        {
            _context.Destinations.Add(Destination);
            await _context.SaveChangesAsync();

            LogService.LogDelegate?.Invoke(string.Format("Destino cadastrado: {0}, {1}", Destination.Name,
                Destination.Country));

            SuccessMessage = string.Format("Destino '{0}, {1}' cadastrado com sucesso!",
                Destination.Name, Destination.Country);

            Destination = new(name: "", country: "");

            return RedirectToPage();
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, string.Format("Erro ao salvar destino: {0}", ex.Message));
            return Page();
        }
    }

    private async Task LoadExistingDestinations()
    {
        ExistingDestinations = await _context.Destinations
            .OrderBy(d => d.Country)
            .ThenBy(d => d.Name)
            .ToListAsync();
    }
}
