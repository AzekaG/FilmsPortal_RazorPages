using Azure;
using FilmsPortal_RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using static System.Net.WebRequestMethods;

namespace FilmsPortal_RazorPages.Pages
{
    public class UploadModel : PageModel
    {
        public IEnumerable<Film> films { get; set; }
        IWebHostEnvironment _appEnvironment;
        ApplicationContext applicationContext { get; set; }

        public Film? film { get; set; }
        public string? Message { get; set; }
        [BindProperty]
        public int id { get; set; }

        [BindProperty]
         public string Name { get; set; }


        [BindProperty]
        public string Jenre { get; set; }


        [BindProperty]
        public string Description { get; set; }


        [BindProperty]
         public int Year { get; set; }

        [BindProperty] 
        public string Poster { get; set; }



        [BindProperty]
        public string Producer { get; set; }


   

      

        public UploadModel(ApplicationContext applicationContext, IWebHostEnvironment appEnvironment)
        {
            this.applicationContext = applicationContext;
            _appEnvironment = appEnvironment;
        }
        [BindProperty] //имя uploadedFile из формы будет привязанн к свойству uploadedFile
        public IFormFile uploadedFile { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            film = new Film();
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
                return  Page();
            }


            film.Poster = HttpContext.Session.GetString("Poster");

            





            applicationContext.Films.Add(film);
            applicationContext.SaveChanges();
            
            return RedirectToPage("./ShowTop");
        }
    }
}
