using CityBreaks.Web.Models;

namespace CityBreaks.Web.Services;

public interface IPropertyService
{
    Task<List<Property>> GetAllAsync();
    Task<Property?> GetByIdAsync(int id);
    Task<List<Property>> GetFilteredAsync(decimal? minPrice, decimal? maxPrice, string? cityName, string? propertyName);
    Task<bool> CreateAsync(Property property);
    Task<bool> DeleteAsync(int id);
}
