﻿using WebBlog6.Models.db;

namespace WebBlog6.Models.Db.Repository
{
    public interface IDataRepository
    {
        Task UserAdd(User user);
        bool UserAccess(ref User user);
        bool UserCookies(ref User user);
        User UserData(User user);
        List<User> UserAll(User user);
        Task BlogAdd(Blog blog);
        Task CommentAdd(Comment comment);
        Task TegBlogsAdd(int sid, int tid);
        Task TegAdd(Teg teg);
        Task TegRem(Teg teg);
    }
}