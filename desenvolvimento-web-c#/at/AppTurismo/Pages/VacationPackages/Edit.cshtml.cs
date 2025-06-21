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
public class EditModel : PageModel
{
    private readonly AppTurismoContext _context;

    public EditModel(AppTurismoContext context) => _context = context;

    [BindProperty] public VacationPackage? VacationPackage { get; set; }

    [BindProperty] public List<int> SelectedDestinations { get; set; } = new();

    public SelectList DestinationOptions { get; set; } = null!;

    public int ActiveReservations =>
        VacationPackage?.Reservations?.Count(r => !r.IsDeleted) ?? 0;

    public int AvailableSpots =>
        (VacationPackage?.MaxCapacity ?? 0) - ActiveReservations;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        if (id <= 0)
        {
            LogService.LogDelegate?.Invoke("ID não encontrado");
            return Page();
        }

        try
        {
            VacationPackage = await _context.VacationPackages
                .Include(v => v.Destinations)
                .Include(v => v.Reservations)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (VacationPackage == null)
            {
                LogService.LogDelegate?.Invoke("Pacote não encontrado");
                return Page();
            }

            SelectedDestinations = VacationPackage.Destinations.Select(d => d.Id).ToList();
            await LoadDestinationsAsync();

            return Page();
        }
        catch (Exception ex)
        {
            LogService.LogDelegate?.Invoke(string.Format("Erro ao carregar pacote: {0}", ex.Message));
            return Page();
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await LoadDestinationsAsync();
            return Page();
        }

        try
        {
            var vacationPackageToUpdate = await _context.VacationPackages
                .Include(v => v.Destinations)
                .Include(v => v.Reservations)
                .FirstOrDefaultAsync(v => v.Id == VacationPackage!.Id);

            if (vacationPackageToUpdate == null)
            {
                LogService.LogDelegate?.Invoke("Pacote não encontrado");
                await LoadDestinationsAsync();
                return Page();
            }

            int activeReservations = vacationPackageToUpdate.Reservations.Count(r => !r.IsDeleted);
            if (VacationPackage?.MaxCapacity < activeReservations)
            {
                ModelState.AddModelError("VacationPackage.MaxCapacity",
                    string.Format("A capacidade não pode ser menor que {0} (reservas ativas).", activeReservations));
                await LoadDestinationsAsync();
                return Page();
            }

            vacationPackageToUpdate.Title = VacationPackage!.Title;
            vacationPackageToUpdate.StartDate = VacationPackage.StartDate;
            vacationPackageToUpdate.Price = VacationPackage.Price;
            vacationPackageToUpdate.MaxCapacity = VacationPackage.MaxCapacity;

            vacationPackageToUpdate.Destinations.Clear();
            if (SelectedDestinations.Any())
            {
                var destinations = await _context.Destinations
                    .Where(d => SelectedDestinations.Contains(d.Id))
                    .ToListAsync();

                foreach (var destination in destinations)
                {
                    vacationPackageToUpdate.Destinations.Add(destination);
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        catch (Exception ex)
        {
            LogService.LogDelegate?.Invoke(string.Format("Erro ao salvar alterações: {0}", ex.Message));
            await LoadDestinationsAsync();
            return Page();
        }
    }

    private async Task LoadDestinationsAsync()
    {
        var destinations = await _context.Destinations
            .OrderBy(d => d.Country)
            .ThenBy(d => d.Name)
            .Select(d => new { d.Id, Display = string.Format("{0}, {1}", d.Name, d.Country) })
            .ToListAsync();

        DestinationOptions = new SelectList(destinations, "Id", "Display");
    }
}
