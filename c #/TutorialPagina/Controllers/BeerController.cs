using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TutorialPagina.Models;
using TutorialPagina.Models.ViewModels;

namespace TutorialPagina.Controllers
{
    public class BeerController(TestTutoContext context) : Controller
    {
        private readonly TestTutoContext _context = context;

        public async Task<ActionResult> Index()
        {
            var beers = _context.Beers.Include(b => b.IdBrandNavigation);
            return View(await beers.ToListAsync());
        }

        public ActionResult Create()
        {
            ViewData["Brands"] = new SelectList(_context.Brands, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BeerViewModel model)
        {
            if (ModelState.IsValid) {
                var beer = new Beer {
                    Name = model.Name,
                    IdBrand = int.Parse(model.IdBrand)
                };

                _context.Beers.Add(beer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Brands"] = new SelectList(_context.Brands, "Id", "Name", model.IdBrand);
            return View(model);
        }
    }
}
