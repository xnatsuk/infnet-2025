using Microsoft.AspNetCore.Mvc.RazorPages;

namespace tp2.Pages.CityManager;

public class CityDetailsModel : PageModel
{
    public string? CityName { get; set; }

    public void OnGet() => CityName = RouteData.Values["cityName"]?.ToString();
}
