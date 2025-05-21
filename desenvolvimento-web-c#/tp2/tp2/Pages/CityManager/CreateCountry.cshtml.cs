using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace tp2.Pages.CityManager;

public class CreateCountryModel : PageModel
{
    public class Country
    {
        public required string CountryName { get; set; }
        public required string CountryCode { get; set; }
    }

    public class InputModel
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [Display(Name = "Nome do País")]
        public required string CountryName { get; set; }

        [Required(ErrorMessage = "Código do país é obrigatório")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O código deve ter exatamente 2 caracteres.")]
        [Display(Name = "Código do País")]
        public required string CountryCode { get; set; }
    }

    [BindProperty]
    public required InputModel Input { get; set; }
    public Country? NewCountry { get; set; }

    public void OnGet() {}

    public void OnPost()
    {
        if (!ModelState.IsValid) return;

        NewCountry = new Country
        {
            CountryName = Input.CountryName,
            CountryCode = Input.CountryCode
        };
    }
}
