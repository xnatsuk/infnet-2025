using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using CityBreaks.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Pages;

public class CreatePropertyModel : PageModel
{
    private readonly IPropertyService _propertyService;
    private readonly CityBreaksContext _context;

    public CreatePropertyModel(IPropertyService propertyService, CityBreaksContext context)
    {
        _propertyService = propertyService;
        _context = context;
    }

    [BindProperty] public Property Property { get; set; } = new();

    public SelectList Cities { get; set; } = null!;
    public string? Message { get; set; }

    public async Task OnGetAsync() => await LoadCitiesAsync();


    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await LoadCitiesAsync();
            return Page();
        }

        bool success = await _propertyService.CreateAsync(Property);

        if (success)
        {
            TempData["SuccessMessage"] = $"Propriedade '{Property.Name}' cadastrada com sucesso!";
            return RedirectToPage("/Index");
        }

        Message = "Erro ao cadastrar a propriedade. Tente novamente.";
        ModelState.AddModelError("", Message);
        await LoadCitiesAsync();
        return Page();
    }

    private async Task LoadCitiesAsync()
    {
        List<City> cities = await _context.Cities
            .Include(c => c.Country)
            .OrderBy(c => c.Country.CountryName)
            .ThenBy(c => c.Name)
            .ToListAsync();

        Cities = new SelectList(
            cities.Select(c => new
            {
                c.Id,
                Display = $"{c.Name}, {c.Country?.CountryName}"
            }),
            "Id",
            "Display"
        );
    }
}
