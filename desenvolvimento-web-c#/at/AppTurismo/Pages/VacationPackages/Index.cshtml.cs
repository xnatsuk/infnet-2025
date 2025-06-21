using AppTurismo.Data;
using AppTurismo.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AppTurismo.Pages.VacationPackages;

public class IndexModel : PageModel
{
    private readonly AppTurismoContext _context;

    public IndexModel(AppTurismoContext context) => _context = context;

    public IList<VacationPackage> VacationPackages { get; set; } = default!;

    public async Task OnGetAsync()
    {
        VacationPackages = await _context.VacationPackages
            .Include(v => v.Destinations)
            .Include(v => v.Reservations)
            .OrderBy(v => v.StartDate)
            .ToListAsync();
    }
}
