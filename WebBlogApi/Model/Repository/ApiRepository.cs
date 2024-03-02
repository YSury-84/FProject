using Microsoft.EntityFrameworkCore;
using WebBlog6.Models.db;
using WebBlog6.Models.Db.Context;
using WebBlogApi.Model.Context;

namespace WebBlogApi.Model.Repository
{
    public class ApiRepository : IApiRepository
    {
        private readonly ApiContext _context;

        // Метод-конструктор для инициализации
        public ApiRepository(ApiContext context)
        {
            _context = context;
        }

        public void TegList(ref List<Teg> listTeg)
        {
            foreach (var teg in _context.Tegs)
            {
                listTeg.Add(teg);
            }
        }
    }
}
