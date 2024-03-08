using FilmsPortal_RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FilmsPortal_RazorPages.Pages
{
    public class DeleteModel : PageModel
    {


        ApplicationContext _context;
        public Film? film { get; set; }

        [BindProperty(SupportsGet = true, Name = "id")]
        public int id { get; set; }


        public string Message { get; set; } = "¬ы действительно хотите удалить фильм? ";
        public DeleteModel(ApplicationContext context)
        {
            _context = context;
        }


        public void OnGet()
        {
            Message = "¬ы действительно хотите удалить этот фильм?" + id;
            HttpContext.Session.SetString("idDeleteFilm", id.ToString());
        }
        public async Task<IActionResult> OnPostAsync()
        {
            int? id = int.Parse(HttpContext.Session.GetString("idDeleteFilm"));
            if (id != null && id!=0)
            {

                var el = _context.Films.Where(x => x.Id == id).FirstOrDefault();
                _context.Films.Remove(el);
               _context.SaveChanges();
                return RedirectToPage("./ShowTop");
            }
             return Page();
        }
    }
}
