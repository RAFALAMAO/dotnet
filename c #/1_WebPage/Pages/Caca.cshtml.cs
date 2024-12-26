using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace c__.Pages;

public class CacaModel : PageModel
{
    private readonly ILogger<CacaModel> _logger;

    public CacaModel(ILogger<CacaModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

