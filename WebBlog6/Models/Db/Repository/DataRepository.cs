using Microsoft.EntityFrameworkCore;
using System.Text;
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

        public int BlogAdd(Blog blog)
        {
            // Добавление публикации
            foreach (var blogs in _context.Blogs)
            {
                if (blog.Id == blogs.Id)
                {
                    _context.Blogs.Remove(blogs);
                }
            }
            var entry = _context.Entry(blog);
            if (entry.State == EntityState.Detached)
                _context.Blogs.AddAsync(blog);
            // Сохранение изенений
            _context.SaveChangesAsync();
            return blog.Id;
        }
        public void BlogAll(ref List<Blog> listBlog)
        {
            foreach (var blog in _context.Blogs)
            {
                listBlog.Add(blog);
            }
        }

        //Работа с базой Comments

        public void CommentAdd(Comment comment)
        {
            // Добавление публикации
            var entry = _context.Entry(comment);
            if (entry.State == EntityState.Detached)
                _context.Comments.AddAsync(comment);
            // Сохранение изенений
            _context.SaveChangesAsync();
        }
        public void CommentsList(ref List<Comment> listComments)
        {
            foreach (var comment in _context.Comments)
            {
                listComments.Add(comment);
            }
        }
        public void CommentDel(Comment comment)
        {
            //Удаление публикации
            foreach (var comments in _context.Comments)
            {
                if (comments.Id == comment.Id)
                {
                    _context.Comments.Remove(comments);
                }
            }
            // Сохранение изенений
            _context.SaveChangesAsync();
        }

        //Работа с базой TegBlogs

        public async Task TegBlogsAdd(int sid, string tid)
        {
            TegBlog tegBlog = new TegBlog();
            tegBlog.BId = sid;
            tegBlog.TId = tid;
            // Добавление публикации
            var entry = _context.Entry(tegBlog);
            if (entry.State == EntityState.Detached)
                _context.TegBlogs.AddAsync(tegBlog);
            // Сохранение изенений
            _context.SaveChangesAsync();
        }
        public async Task TegBlogsRem(int sid, string tid)
        {
            foreach (var bteg in _context.TegBlogs)
            {
                if (bteg.BId == sid && bteg.TId == tid)
                {
                    _context.TegBlogs.Remove(bteg);
                }
            }
            // Сохранение изенений
            _context.SaveChangesAsync();
        }
        public void TegBlogList(ref List<TegBlog> listTegBlogs)
        {
            foreach (var teg in _context.TegBlogs)
            {
                listTegBlogs.Add(teg);
            }
        }

        //Работа с базой Teg

        public async Task TegAdd(Teg teg)
        {
            bool tadd = true;
            foreach (var xteg in _context.Tegs)
                {
                if (xteg.TegName == teg.TegName)
                {
                    tadd = false;
                }
            }
            if (tadd == true)
            {
                // Добавление тега
                var entry = _context.Entry(teg);
                if (entry.State == EntityState.Detached)
                    _context.Tegs.AddAsync(teg);
                // Сохранение изенений
                _context.SaveChangesAsync();
            } else
            {
                // Удаление тага - если он уже есть в списке
                _context.Tegs.Remove(teg);
                // Сохранение изенений
                _context.SaveChangesAsync();
            }
        }

        public void TegList(ref List<Teg> listTeg)
        {
            foreach (var teg in _context.Tegs)
            {
                listTeg.Add(teg);
            }
        }

        public async Task LogAdd(Log log)
        {
            // Добавление записи в Log
            var entry = _context.Entry(log);
            if (entry.State == EntityState.Detached)
                _context.Logs.AddAsync(log);
            // Сохранение изенений
            _context.SaveChangesAsync();
        }

    }
}
