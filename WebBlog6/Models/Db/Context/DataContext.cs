using Microsoft.EntityFrameworkCore;
using WebBlog6.Models.db;

namespace WebBlog6.Models.Db.Context
{
    public class DataContext : DbContext
    {
        /// Ссылка на таблицу Users
        public DbSet<User> Users { get; set; }
        public DbSet<Teg> Tegs { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<TegBlog> TegBlogs { get; set; }
        public DbSet<Log> Logs { get; set; }

        // Логика взаимодействия с таблицами в БД
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
