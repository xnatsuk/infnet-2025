using AppTurismo.Data;
using AppTurismo.Models;
using AppTurismo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AppTurismo.Pages.VacationPackages;

[Authorize]
public class CreateModel : PageModel
{
    private readonly AppTurismoContext _context;

    public CreateModel(AppTurismoContext context) => _context = context;

    [BindProperty] public VacationPackage VacationPackage { get; set; } = default!;

    [BindProperty] public List<int> SelectedDestinations { get; set; } = new();

    public SelectList DestinationOptions { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync()
    {
        await LoadDestinations();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await LoadDestinations();
            return Page();
        }

        _context.VacationPackages.Add(VacationPackage);
        await _context.SaveChangesAsync();

        if (SelectedDestinations.Any())
        {
            var destinations = await _context.Destinations
                .Where(d => SelectedDestinations.Contains(d.Id))
                .ToListAsync();

            VacationPackage.Destinations = destinations;
            await _context.SaveChangesAsync();

            LogService.LogDelegate?.Invoke(string.Format("Pacote de Viagem {0} criado com sucesso!",
                VacationPackage.Title));
        }

        return RedirectToPage("./Index");
    }

    private async Task LoadDestinations()
    {
        var destinations = await _context.Destinations
            .OrderBy(d => d.Country)
            .ThenBy(d => d.Name)
            .Select(d => new { d.Id, Display = $"{d.Name}, {d.Country}" })
            .ToListAsync();

        DestinationOptions = new SelectList(destinations, "Id", "Display");
    }
}
