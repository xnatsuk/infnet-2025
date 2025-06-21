using AppTurismo.Data;
using AppTurismo.Models;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AppTurismo.Pages;

public class IndexModel : PageModel
{
    private readonly AppTurismoContext _context;

    public IndexModel(AppTurismoContext context) => _context = context;

    public int TotalClients { get; set; }
    public int AvailablePackages { get; set; }
    public int ActiveReservations { get; set; }
    public int TotalDestinations { get; set; }

    public List<VacationPackage> UpcomingVacations { get; set; } = new();

    public async Task OnGetAsync()
    {
        await LoadStatistics();
        await LoadUpcomingPackages();
    }

    private async Task LoadStatistics()
    {
        TotalClients = await _context.Clients.CountAsync();

        AvailablePackages = await _context.VacationPackages
            .Where(p => p.StartDate > DateTime.Now)
            .CountAsync();

        ActiveReservations = await _context.Reservations.CountAsync();

        TotalDestinations = await _context.Destinations.CountAsync();
    }

    private async Task LoadUpcomingPackages()
    {
        List<VacationPackage> packages = await _context.VacationPackages
            .Where(p => p.StartDate > DateTime.Now)
            .OrderBy(p => p.StartDate)
            .ToListAsync();
        UpcomingVacations = packages;
    }
}
