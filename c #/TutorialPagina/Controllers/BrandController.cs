using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TutorialPagina.Models;

namespace TutorialPagina.Controllers
{
    public class BrandController : Controller
    {
        private readonly TestTutoContext _context;

        public BrandController(TestTutoContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            return View(await _context.Brands.ToListAsync());
        }

    }
}
