using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace tp2.Pages.CityManager;

public class CreateCountryWithCustomValidationModel : PageModel
{
    public class Country
    {
        public string? CountryName { get; set; }
        public string? CountryCode { get; set; }
    }

    public class InputModel
    {
        [Required(ErrorMessage = "O nome do país é obrigatório.")]
        [Display(Name = "Nome do País")]
        public string? CountryName { get; set; }

        [Required(ErrorMessage = "O código do país é obrigatório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O código do país deve ter exatamente 2 caracteres.")]
        [Display(Name = "Código do País (2 letras)")]
        public string? CountryCode { get; set; }
    }

    [BindProperty]
    public InputModel? Input { get; set; }
    public Country? NewCountry { get; set; }

    public void OnGet() {}

    public void OnPost()
    {
        if (!ModelState.IsValid) return;
        if (Input?.CountryName is null || Input.CountryCode is null) return;

        char firstLetterName = char.ToUpper(Input.CountryName[0]);
        char firstLetterCode = char.ToUpper(Input.CountryCode[0]);

        if (firstLetterName != firstLetterCode)
            ModelState.AddModelError("Input.CountryCode",
                "O código está no formato errado.");

        NewCountry = new Country
        {
            CountryName = Input?.CountryName,
            CountryCode = Input?.CountryCode
        };
    }
}
