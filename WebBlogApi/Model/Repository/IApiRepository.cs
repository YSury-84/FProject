using WebBlog6.Models.db;
using WebBlog6.Models.Db;

namespace WebBlogApi.Model.Repository
{
    public interface IApiRepository
    {
        void TegList(ref List<Teg> listTeg);
    }
}
