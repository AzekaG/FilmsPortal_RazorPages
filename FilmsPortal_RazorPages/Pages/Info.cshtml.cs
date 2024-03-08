using FilmsPortal_RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FilmsPortal_RazorPages.Pages
{
    public class InfoModel : PageModel
    {


        ApplicationContext _context;
        public Film? film {  get; set; }
        public  string? Message { get; set; }
        [BindProperty(SupportsGet = true, Name = "id")]
        public int id { get; set; }

        public InfoModel(ApplicationContext context) { 
            _context = context;
        }
        public async Task OnGet()
        {
            film = await _context.Films.Where(film => film.Id == id).FirstAsync();
           
        }
    }
}
