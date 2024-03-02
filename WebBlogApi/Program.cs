using Microsoft.EntityFrameworkCore;
using WebBlog6.Models.Db.Context;
using WebBlog6.Models.Db.Repository;
using WebBlogApi.Model.Context;
using WebBlogApi.Model.Repository;

namespace WebBlogApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //string connection = builder.Configuration.GetConnectionString("DefaultConnection");
            //builder.Services.AddDbContext<ApiContext>(options => options.UseSqlite(connection));
            //builder.Services.AddScoped<IApiContext, ApiRepository>();

            string connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(connection));
            builder.Services.AddScoped<IDataRepository, DataRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}