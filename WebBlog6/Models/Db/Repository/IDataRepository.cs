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
        void BlogAll(ref List<Blog> listBlog);
        void CommentAdd(Comment comment);
        void CommentsList(ref List<Comment> listComments);
        void CommentDel(Comment comment);
        Task TegBlogsAdd(int sid, string tid);
        Task TegBlogsRem(int sid, string tid);
        void TegBlogList(ref List<TegBlog> listTegBlogs);
        Task TegAdd(Teg teg);
        void TegList(ref List<Teg> listTeg);
        Task LogAdd(Log log);
    }
}
