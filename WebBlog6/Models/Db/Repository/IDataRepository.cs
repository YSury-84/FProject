using WebBlog6.Models.db;

namespace WebBlog6.Models.Db.Repository
{
    public interface IDataRepository
    {
        Task UserAdd(User user);
        bool UserAccess(ref User user);
        bool UserCookies(ref User user);
        void UserAll(ref List<User> listUser);
        Task BlogAdd(Blog blog);
        Task CommentAdd(Comment comment);
        Task TegBlogsAdd(int sid, int tid);
        Task TegAdd(Teg teg);
        Task TegRem(Teg teg);
    }
}
