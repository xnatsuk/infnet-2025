using AppTurismo.Data;
using AppTurismo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AppTurismo.Pages;

public class PackageDetailsModel : PageModel
{
    private readonly AppTurismoContext _context;

    public PackageDetailsModel(AppTurismoContext context) => _context = context;

    [BindProperty(SupportsGet = true)] public int Id { get; set; }

    public VacationPackage? VacationPackage { get; set; }

    public int ActiveReservations => VacationPackage?.Reservations?.Count(r => !r.IsDeleted) ?? 0;

    public int AvailableSpots => (VacationPackage?.MaxCapacity ?? 0) - ActiveReservations;

    public bool IsAvailable => AvailableSpots > 0;

    public bool CanReserve =>
        VacationPackage != null &&
        VacationPackage.StartDate > DateTime.Now &&
        AvailableSpots > 0;

    public string? ErrorMessage { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        if (Id <= 0)
        {
            ErrorMessage = "ID do pacote inválido.";
            return Page();
        }

        try
        {
            VacationPackage = await _context.VacationPackages
                .Include(vp => vp.Destinations)
                .Include(vp => vp.Reservations)
                .FirstOrDefaultAsync(vp => vp.Id == Id);

            if (VacationPackage == null)
                ErrorMessage = "Pacote não encontrado.";
        }
        catch (Exception ex)
        {
            ErrorMessage = string.Format("Erro ao carregar pacote: {0}", ex.Message);
        }

        return Page();
    }
}
