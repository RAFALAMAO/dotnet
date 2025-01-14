using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TutorialPagina.Models;
using TutorialPagina.Models.ViewModels;

namespace TutorialPagina.Controllers.Api
{
  [Route("api/[controller]")]
  [ApiController]
  public class ApiBeerController : ControllerBase
  {
    public readonly TestTutoContext _context;

    public ApiBeerController(TestTutoContext context)
    {
      _context = context;
    }

    public async Task<List<BeerBrandViewModel>> Get()
      => await _context.Beers.Include(b => b.IdBrandNavigation)
      .Select(b => new BeerBrandViewModel
      {
        Id = b.Id,
        Name = b.Name,
        Brand = b.IdBrandNavigation!.Name
      })
      .ToListAsync();
  }
}
