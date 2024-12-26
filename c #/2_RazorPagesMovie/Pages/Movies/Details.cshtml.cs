using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using _2_RazorPagesMovie.Data;
using _2_RazorPagesMovie.Models;

namespace _2_RazorPagesMovie.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly _2_RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public DetailsModel(_2_RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);

            if (movie is not null)
            {
                Movie = movie;

                return Page();
            }

            return NotFound();
        }
    }
}
