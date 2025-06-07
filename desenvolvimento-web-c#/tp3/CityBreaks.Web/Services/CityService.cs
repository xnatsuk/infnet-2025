using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Services;

public class CityService : ICityService
{
    private readonly CityBreaksContext _context;
    public CityService(CityBreaksContext context) => _context = context;

    public async Task<List<City>> GetAllAsync() =>
        await _context.Cities
            .Include(c => c.Country)
            .Include(c => c.Properties
                .Where(p => p.DeletedAt == null))
            .ToListAsync();


    public async Task<City> GetByNameAsync(string name) =>
        await _context.Cities
            .Include(c => c.Country)
            .Include(c => c.Properties
                .Where(p => p.DeletedAt == null))
            .FirstOrDefaultAsync(c => EF.Functions.Collate(c.Name, "NOCASE") == name) ??
        throw new InvalidOperationException();
}
