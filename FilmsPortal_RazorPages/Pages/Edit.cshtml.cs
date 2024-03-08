using FilmsPortal_RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FilmsPortal_RazorPages.Pages
{
    public class EditModel : PageModel
    {

        ApplicationContext _context;
        IWebHostEnvironment _appEnvironment;
        public Film? film { get; set; }
        public string? Message { get; set; }
        [BindProperty(SupportsGet = true, Name = "id")]
        public int id { get; set; }

        [BindProperty]
        public string? Name { get; set; }


        [BindProperty]
        public string? Jenre { get; set; }


        [BindProperty]
        public string? Description { get; set; }


        [BindProperty]
        public int Year { get; set; }



        [BindProperty]
        public string? Producer { get; set; }


        public EditModel(ApplicationContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        [BindProperty] 
        public IFormFile uploadedFile { get; set; } = default!;
        public async Task OnGet()
        {

            HttpContext.Session.SetString("idFilm", id.ToString());
            film = await _context.Films.Where(film => film.Id == id).FirstAsync();
            Name = film.Name;
            Description = film.Description;
            Year = film.Year;   
            Producer = film.Producer;
            Jenre = film.Jenre;
        }


        public async Task<IActionResult> OnPostAsync()
        {
            int? id = int.Parse(HttpContext.Session.GetString("idFilm"));
            film = await _context.Films.Where(film => film.Id == id).FirstAsync();
            film.Producer = Producer;
            film.Description = Description;
            film.Year = Year;
            film.Producer = Producer;
            film.Jenre = Jenre;
            film.Name = Name;
            
            if (uploadedFile != null)
            {
                string path = "/Files/" + uploadedFile.FileName; /// имя файла

                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);  // копируем файл в поток
                }
                film.Poster = path;

                HttpContext.Session.SetString("Poster", film.Poster);
                return Page();
            }

            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("Poster")))
            {
                film.Poster = HttpContext.Session.GetString("Poster");
            }

   
            _context.Films.Update(film);
            _context.SaveChanges();

            return RedirectToPage("./ShowTop");
        }



    }
}
