using Microsoft.EntityFrameworkCore;
using WebBlog6.Models.db;
using WebBlog6.Models.Db.Context;

namespace WebBlog6.Models.Db.Repository
{
    public class DataRepository : IDataRepository
    {
        // ссылка на контекст
        private readonly DataContext _context;

        // Метод-конструктор для инициализации
        public DataRepository(DataContext context)
        {
            _context = context;
        }

        //Работа с базой Users

        public async Task UserAdd(User user)
        {
            // Добавление пользователя

            foreach (var people in _context.Users)
            {
                if (people.Login == user.Login)
                {
                    _context.Users.Remove(people);
                }
            }
            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
                _context.Users.AddAsync(user);
            // Сохранение изенений
            _context.SaveChangesAsync();
        }
        public bool UserAccess(ref User user)
        {
            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
            {
                foreach (var people in _context.Users)
                {
                    if (people.Login == user.Login)
                        if (people.Pass == user.Pass)
                        {
                            user = people;
                            return true;
                        }
                }
            }
            return false;
        }

        public bool UserCookies(ref User user)
        {
            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
            {
                foreach (var people in _context.Users)
                {
                    if (people.Login == user.Login)
                        {
                            user = people;
                            return true;
                        }
                }
            }
            return false;
        }

        public void UserAll(ref List<User> listUser)
        {
           foreach (var people in _context.Users)
           {
            listUser.Add(people);
           }
        }

        //Работа с базой Blogs

        public async Task BlogAdd(Blog blog)
        {
            // Добавление публикации
            var entry = _context.Entry(blog);
            if (entry.State == EntityState.Detached)
                _context.Blogs.AddAsync(blog);
            // Сохранение изенений
            _context.SaveChangesAsync();
        }

        //Работа с базой Comments

        public async Task CommentAdd(Comment comment)
        {
            // Добавление публикации
            var entry = _context.Entry(comment);
            if (entry.State == EntityState.Detached)
                _context.Comments.AddAsync(comment);
            // Сохранение изенений
            _context.SaveChangesAsync();
        }

        //Работа с базой TegBlogs

        public async Task TegBlogsAdd(int sid, int tid)
        {
            TegBlog tegBlog = new TegBlog();
            tegBlog.SId = sid;
            tegBlog.TId = tid;
            // Добавление публикации
            var entry = _context.Entry(tegBlog);
            if (entry.State == EntityState.Detached)
                _context.TegBlogs.AddAsync(tegBlog);
            // Сохранение изенений
            _context.SaveChangesAsync();
        }

        //Работа с базой Teg

        public async Task TegAdd(Teg teg)
        {
            // Добавление публикации
            var entry = _context.Entry(teg);
            if (entry.State == EntityState.Detached)
                _context.Tegs.AddAsync(teg);
            // Сохранение изенений
            _context.SaveChangesAsync();
        }

        public async Task TegRem(Teg teg)
        {
            // Добавление публикации
            var entry = _context.Entry(teg);
            if (entry.State == EntityState.Detached)
                _context.Tegs.Remove(teg);
            // Сохранение изенений
            _context.SaveChangesAsync();
        }

    }
}
