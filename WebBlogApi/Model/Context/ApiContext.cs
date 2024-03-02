using Microsoft.EntityFrameworkCore;
using WebBlog6.Models.db;
using WebBlog6.Models.Db;

namespace WebBlogApi.Model.Context
{
    public class ApiContext : DbContext
    {
        /// Ссылка на таблицу Users
        public DbSet<Teg> Tegs { get; set; }

        // Логика взаимодействия с таблицами в БД
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
