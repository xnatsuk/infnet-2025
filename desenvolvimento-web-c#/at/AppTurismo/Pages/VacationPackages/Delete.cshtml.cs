using AppTurismo.Data;
using AppTurismo.Models;
using AppTurismo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AppTurismo.Pages.VacationPackages;

[Authorize]
public class DeleteModel : PageModel
{
    private readonly AppTurismoContext _context;

    public DeleteModel(AppTurismoContext context) => _context = context;

    [BindProperty] public VacationPackage? VacationPackage { get; set; }

    public int ActiveReservations =>
        VacationPackage?.Reservations?.Count(r => !r.IsDeleted) ?? 0;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        if (id <= 0)
        {
            LogService.LogDelegate?.Invoke("ID inválido.");
            return Page();
        }

        try
        {
            VacationPackage = await _context.VacationPackages
                .Include(v => v.Destinations)
                .Include(v => v.Reservations)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (VacationPackage == null)
                LogService.LogDelegate?.Invoke("Pacote não encontrado.");

            return Page();
        }
        catch (Exception ex)
        {
            LogService.LogDelegate?.Invoke(string.Format("Erro ao carregar pacote: {0}", ex.Message));
            return Page();
        }
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        try
        {
            var vacationPackage = await _context.VacationPackages
                .Include(v => v.Destinations)
                .Include(v => v.Reservations)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (vacationPackage == null)
            {
                LogService.LogDelegate?.Invoke("Pacote não encontrado.");
                return Page();
            }

            var activeReservations = vacationPackage.Reservations.Count(r => !r.IsDeleted);
            if (activeReservations > 0)
                foreach (var reservation in vacationPackage.Reservations)
                {
                    _context.Reservations.Remove(reservation);
                }

            vacationPackage.Destinations.Clear();

            _context.VacationPackages.Remove(vacationPackage);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        catch (Exception ex)
        {
            LogService.LogDelegate?.Invoke(string.Format("Erro ao excluir pacote: {0}", ex.Message));

            VacationPackage = await _context.VacationPackages
                .Include(v => v.Destinations)
                .Include(v => v.Reservations)
                .FirstOrDefaultAsync(v => v.Id == id);

            return Page();
        }
    }
}
