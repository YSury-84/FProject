using Microsoft.EntityFrameworkCore;
using WebBlog6.Models.Db.Context;
using WebBlog6.Models.Db.Repository;
using System.IO;

namespace WebBlog6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // получаем строку подключения из файла конфигурации
            string connection = builder.Configuration.GetConnectionString("DefaultConnection");
            //string connection = "Data Source='C:\\Users\\student\\source\\repos\\YSury-84\\FProject\\DBLite\\blog.db';Mode=ReadWriteCreate;Cache=Shared";

            // добавляем контекст ApplicationContext в качестве сервиса в приложение
            builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(connection));

            builder.Services.AddScoped<IDataRepository, DataRepository>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // обработка ошибок HTTP
            string readText = File.ReadAllText("wwwroot\\404.html");
            app.UseStatusCodePages("text/html", readText);

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}