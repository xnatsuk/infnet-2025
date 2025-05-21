using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace tp2.Pages.CityManager;

public class CreateCityModel : PageModel
{
    // [BindProperty]
    public string? CityName { get; set; }
    public bool FormSubmitted { get; set; }

    public void OnGet() => FormSubmitted = false;


    public void OnPost(string cityName)
    {
        FormSubmitted = true;
        if (!ModelState.IsValid) return;
        CityName = cityName;
    }
}
