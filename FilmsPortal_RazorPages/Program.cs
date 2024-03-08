using FilmsPortal_RazorPages.Models;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddMvc();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));


// ��������� � ���������� ������� Razor Pages
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseSession();
app.UseStaticFiles(); // ������������ ������� � ������ � ����� wwwroot
// ��������� ��������� ������������� ��� Razor Pages
app.MapRazorPages();

app.Run();


