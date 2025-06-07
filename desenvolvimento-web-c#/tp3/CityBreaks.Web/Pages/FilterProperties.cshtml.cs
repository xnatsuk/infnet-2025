using CityBreaks.Web.Models;
using CityBreaks.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Web.Pages
{
    public class FilterPropertiesModel : PageModel
    {
        private readonly IPropertyService _propertyService;

        public FilterPropertiesModel(IPropertyService propertyService) => _propertyService = propertyService;

        [BindProperty(SupportsGet = true)] public decimal? MinPrice { get; set; }

        [BindProperty(SupportsGet = true)] public decimal? MaxPrice { get; set; }

        [BindProperty(SupportsGet = true)] public string? CityName { get; set; }

        [BindProperty(SupportsGet = true)] public string? PropertyName { get; set; }

        public List<Property> Properties { get; set; } = new();

        public bool HasFilters => MinPrice.HasValue || MaxPrice.HasValue ||
                                  !string.IsNullOrEmpty(CityName) || !string.IsNullOrEmpty(PropertyName);

        public async Task OnGetAsync()
        {
            if (!HasFilters) Properties = await _propertyService.GetAllAsync();
            Properties = await _propertyService.GetFilteredAsync(MinPrice, MaxPrice, CityName, PropertyName);
        }
    }
}
