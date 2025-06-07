using CityBreaks.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Web.Pages;

public class DeletePropertyModel : PageModel
{
    private readonly IPropertyService _propertyService;

    public DeletePropertyModel(IPropertyService propertyService) => _propertyService = propertyService;

    public async Task<IActionResult> OnPostAsync(int id)
    {
        bool success = await _propertyService.DeleteAsync(id);

        if (!success) TempData["ErrorMessage"] = "Erro ao excluir a propriedade.";
        return RedirectToPage("/Index");
    }
}
