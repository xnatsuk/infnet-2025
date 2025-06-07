using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using CityBreaks.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Pages
{
    public class EditPropertyModel : PageModel
    {
        private readonly IPropertyService _propertyService;
        private readonly CityBreaksContext _context;

        public EditPropertyModel(IPropertyService propertyService, CityBreaksContext context)
        {
            _propertyService = propertyService;
            _context = context;
        }

        [BindProperty] public Property? Property { get; set; } = new();

        public SelectList? Cities { get; set; }
        public string? Message { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Property = await _propertyService.GetByIdAsync(id);

            if (Property == null) return NotFound();

            await LoadCitiesAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Property == null)
            {
                await LoadCitiesAsync();
                return Page();
            }

            Property? existingProperty = await _context.Properties.FindAsync(Property.Id);
            if (existingProperty == null)
                return NotFound();

            if (await TryUpdateModelAsync(existingProperty, nameof(Property),
                    p => p.Name, p => p.PricePerNight, p => p.CityId))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = $"Propriedade '{existingProperty.Name}' atualizada com sucesso!";
                    return RedirectToPage("/Index");
                }
                catch
                {
                    Message = "Erro ao atualizar a propriedade. Tente novamente.";
                }
            }

            return Page();
        }

        private async Task LoadCitiesAsync()
        {
            List<City> cities = await _context.Cities
                .Include(c => c.Country)
                .OrderBy(c => c.Country.CountryName)
                .ThenBy(c => c.Name)
                .ToListAsync();

            if (Property != null)
                Cities = new SelectList(
                    cities.Select(c => new
                    {
                        c.Id,
                        Display = $"{c.Name}, {c.Country?.CountryName}"
                    }),
                    "Id",
                    "Display",
                    Property.CityId
                );
        }
    }
}
