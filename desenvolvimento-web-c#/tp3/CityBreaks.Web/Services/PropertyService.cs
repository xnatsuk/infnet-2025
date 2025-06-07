using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Services;

public class PropertyService : IPropertyService
{
    private readonly CityBreaksContext _context;

    public PropertyService(CityBreaksContext context) => _context = context;

    public async Task<List<Property>> GetAllAsync() => await _context.Properties
        .Include(p => p.City)
        .ThenInclude(c => c.Country)
        .Where(p => p.DeletedAt == null)
        .ToListAsync();

    public async Task<Property?> GetByIdAsync(int id) => await _context.Properties
        .Include(p => p.City)
        .ThenInclude(c => c.Country)
        .FirstOrDefaultAsync(p => p.Id == id && p.DeletedAt == null);

    public async Task<List<Property>> GetFilteredAsync(decimal? minPrice, decimal? maxPrice, string? cityName,
        string? propertyName)
    {
        IQueryable<Property> query = _context.Properties
            .Include(p => p.City)
            .ThenInclude(c => c.Country)
            .Where(p => p.DeletedAt == null)
            .AsQueryable();

        if (minPrice.HasValue)
            query = query.Where(p => p.PricePerNight >= minPrice.Value);

        if (maxPrice.HasValue)
            query = query.Where(p => p.PricePerNight <= maxPrice.Value);

        if (!string.IsNullOrEmpty(cityName))
            query = query.Where(p => p.City != null && EF.Functions.Collate(p.City.Name, "NOCASE").Contains(cityName));

        if (!string.IsNullOrEmpty(propertyName))
            query = query.Where(p => EF.Functions.Collate(p.Name, "NOCASE").Contains(propertyName));

        return await query.ToListAsync();
    }

    public async Task<bool> CreateAsync(Property property)
    {
        try
        {
            await _context.Properties.AddAsync(property);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            Property? property = await _context.Properties.FindAsync(id);
            if (property == null) return false;
            property.DeletedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
