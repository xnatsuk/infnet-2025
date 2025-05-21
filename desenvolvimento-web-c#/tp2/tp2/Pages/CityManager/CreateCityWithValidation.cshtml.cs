using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace tp2.Pages.CityManager;

public class CreateCityWithValidationModel : PageModel
{
    public class InputModel
    {
        [Required(ErrorMessage = "Nome obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve ter ao menos 3 caracteres")]
        [Display(Name = "Nome da Cidade")]
        public required string CityName { get; set; }
    }

    [BindProperty]
    public required InputModel Input { get; set; }
    public string? CityNameSubmitted { get; set; }
    public bool FormSubmitted { get; set; }

    public void OnGet() => FormSubmitted = false;

    public void OnPost()
    {
        FormSubmitted = true;

        if (!ModelState.IsValid) return;

        CityNameSubmitted = Input.CityName;
    }
}
