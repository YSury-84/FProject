using WebBlog6.Models.db;

namespace WebBlog6.Models.Db.Repository
{
    public interface IDataRepository
    {
        Task UserAdd(User user);
        bool UserAccess(ref User user);
        bool UserCookies(ref User user);
        void UserAll(ref List<User> listUser);
        int BlogAdd(Blog blog);
        Task CommentAdd(Comment comment);
        Task TegBlogsAdd(int sid, string tid);
        Task TegAdd(Teg teg);
        void TegList(ref List<Teg> listTeg);
    }
}
