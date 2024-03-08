using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FilmsPortal_RazorPages.Models
{
    public class Film
    {
        public int Id { get; set; }
   
        [DisplayName("Название")]

        public string? Name { get; set; }
      
        [DisplayName("Описание")]
        public string? Description { get; set; }
      
        [DisplayName("Жанр")]
        public string? Jenre { get; set; }
       
        [DisplayName("Год")]
        [Range(1985, 2024, ErrorMessage = "Недопустимый год")]
        public int Year { get; set; }
       
        [DisplayName("Режиссёр")]
        public string? Producer { get; set; }
     
        [DisplayName("Постер")]
        public string? Poster { get; set; }

    }
}
