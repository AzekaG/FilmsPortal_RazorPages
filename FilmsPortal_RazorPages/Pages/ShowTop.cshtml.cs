using FilmsPortal_RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FilmsPortal_RazorPages.Pages
{
    public class ShowTopModel : PageModel
    {
        public IEnumerable<Film> filemodel { get; set; } = default!;
        ApplicationContext _context;

        public int Id { get; set; }
        [Required(ErrorMessage = "���� ������ ���� �����������")]
        [DisplayName("��������")]

        public string? Name { get; set; }
        [Required(ErrorMessage = "���� ������ ���� �����������")]
        [DisplayName("��������")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "���� ������ ���� �����������")]
        [DisplayName("����")]
        public string? Jenre { get; set; }
        [Required(ErrorMessage = "���� ������ ���� �����������")]
        [DisplayName("���")]
        [Range(1985, 2024, ErrorMessage = "������������ ���")]
        public int Year { get; set; }
        [Required(ErrorMessage = "���� ������ ���� �����������")]
        [DisplayName("�������")]
        public string? Producer { get; set; }
        [Required(ErrorMessage = "���� ������ ���� �����������")]
        [DisplayName("������")]
        public string? Poster { get; set; }

        IWebHostEnvironment _environment;

        public ShowTopModel(ApplicationContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }


        public async Task OnGetAsync()
        {
            if(_context!=null)
            {
                filemodel = await _context.Films.ToListAsync();
            }
        }



    }
}
