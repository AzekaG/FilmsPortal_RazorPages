using FilmsPortal_RazorPages.Models;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddMvc();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));


// Добавляем в приложение сервисы Razor Pages
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseSession();
app.UseStaticFiles(); // обрабатывает запросы к файлам в папке wwwroot
// Добавляем поддержку маршрутизации для Razor Pages
app.MapRazorPages();

app.Run();


