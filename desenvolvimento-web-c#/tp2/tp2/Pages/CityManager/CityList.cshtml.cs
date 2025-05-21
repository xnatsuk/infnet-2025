using Microsoft.AspNetCore.Mvc.RazorPages;

namespace tp2.Pages.CityManager;

public class CityListModel : PageModel
{
    public List<string> Cities { get; set; } =
    [
        "Rio de Janeiro",
        "São Paulo",
        "Brasília",
        "Salvador",
        "Fortaleza"
    ];

    public void OnGet() {}
}
