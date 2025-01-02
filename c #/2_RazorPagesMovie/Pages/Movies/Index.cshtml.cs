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

    public class IndexModel : PageModel
    {
        private readonly _2_RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public IndexModel(_2_RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }

        // protected void Button1_Click(object sender, EventArgs e)
        // {
        //     int MyCount = Convert.ToInt32(Label1.Text);

        //     MyCount += 1;

        //     Label1.Text = MyCount.ToString();
        // }
    }
}
