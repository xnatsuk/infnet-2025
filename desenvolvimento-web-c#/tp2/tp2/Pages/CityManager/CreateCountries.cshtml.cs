using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace tp2.Pages.CityManager;

public class CreateCountriesModel : PageModel
{
    public class Country
    {
        public string? CountryName { get; set; }
        public string? CountryCode { get; set; }
    }

    public class CountryInputModel
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [Display(Name = "Nome do País")]
        public string? CountryName { get; set; }

        [Required(ErrorMessage = "O código do país é obrigatório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O código deve ter exatamente 2 caracteres.")]
        [Display(Name = "Código do País (2 letras)")]
        public string? CountryCode { get; set; }
    }

    [BindProperty]
    public List<CountryInputModel>? CountryInputs { get; set; }
    public List<Country>? CountriesSubmitted { get; set; }

    public void OnGet()
    {
        CountryInputs = [];
        for (var i = 0; i < 5; i++) CountryInputs.Add(new CountryInputModel());
    }

    public void OnPost()
    {
        if (!ModelState.IsValid) return;
        if (CountryInputs == null) return;

        List<CountryInputModel> filledInputs = CountryInputs.Where(c =>
            !string.IsNullOrEmpty(c.CountryName) &&
            !string.IsNullOrEmpty(c.CountryCode)).ToList();

        // converte para Country
        CountriesSubmitted = filledInputs.Select(input => new Country
        {
            CountryName = input.CountryName,
            CountryCode = input.CountryCode
        }).ToList();
    }
}
