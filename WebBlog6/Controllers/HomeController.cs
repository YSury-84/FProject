using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebBlog6.Models;
using WebBlog6.Models.db;
using WebBlog6.Models.Db;
using WebBlog6.Models.Db.Repository;

namespace WebBlog6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // ссылка на репозиторий
        public readonly IDataRepository _data;

        public HomeController(ILogger<HomeController> logger, IDataRepository data)
        {
            _logger = logger;
            _data = data;
        }

        public IActionResult Index(User getuser)
        {
            //Если реквизиты доступа сохранены в Куках
            string wbLogin = Request.Cookies["wbLogin"];
            if (wbLogin != null && wbLogin != "")
            {
                User user = new User() { Login = wbLogin };
                if (_data.UserCookies(ref user))
                {
                    //Передача пользователя
                    ViewBag.user = user;
                    //Передача блогов
                    List<Blog> listBlogs = new List<Blog>();
                    _data.BlogAll(ref listBlogs);
                    ViewBag.blogs = listBlogs;
                    //Передача тегов

                    //Передача комментариев
                    List<Comment> listComments = new List<Comment>();
                    _data.CommentsList(ref listComments);
                    ViewBag.listComments = listComments;
                    Log log = new Log() { TimeReg = Convert.ToString(DateTime.Now), Message = "Index", Login = user.Login };
                    _data.LogAdd(log);
                    return View();
                }
                return View("Access");
            }
            else
            {
                if (getuser != null)
                {
                    if (getuser.Login != "" && getuser.Login != null)
                    {
                        if (getuser.Fio == "" || getuser.Fio == null)
                        {
                            //Если пришли реквизиты доступа (нажата кнопка Вход)
                            User people = new User();
                            people.Login = getuser.Login;
                            people.Pass = getuser.Pass;
                            if (_data.UserAccess(ref people))
                            {
                                Response.Cookies.Append("wbLogin", getuser.Login);
                                //Передача пользователя
                                ViewBag.user = people;
                                //Передача блогов
                                List<Blog> listBlogs = new List<Blog>();
                                _data.BlogAll(ref listBlogs);
                                ViewBag.blogs = listBlogs;
                                //Передача тегов

                                //Передача комментариев
                                List<Comment> listComments = new List<Comment>();
                                _data.CommentsList(ref listComments);
                                ViewBag.listComments = listComments;
                                Log log = new Log() { TimeReg = Convert.ToString(DateTime.Now), Message = "Index", Login = people.Login };
                                _data.LogAdd(log);
                                return View();
                            }
                        }
                        else
                        {
                            getuser.RegDate = Convert.ToString(DateTime.Now);
                            getuser.Role = "user";
                            //Регистрация нового пользователя
                            _data.UserAdd(getuser);
                            Log log = new Log() { TimeReg = Convert.ToString(DateTime.Now), Message = "Index", Login = getuser.Login };
                            _data.LogAdd(log);
                            return View("Access");
                        }
                    }
                }
            }
            return View("Access");
        }

        public IActionResult Access()
        {
            //Авторизация не требуется
            Log log = new Log() { TimeReg = Convert.ToString(DateTime.Now), Message = "Access", Login = "" };
            _data.LogAdd(log);
            return View();
        }

        public IActionResult About()
        {
            //Сброс авторизации
            Response.Cookies.Append("wbLogin", "");
            //Авторизация не требуется
            Log log = new Log() { TimeReg = Convert.ToString(DateTime.Now), Message = "About", Login = "" };
            _data.LogAdd(log);
            return View();
        }

        public IActionResult Register()
        {
            //Авторизация не требуется
            Log log = new Log() { TimeReg = Convert.ToString(DateTime.Now), Message = "Register", Login = "" };
            _data.LogAdd(log);
            return View();
        }

        public IActionResult AdminPanel()
        {
            //Стандартная схема загрузки с авторизацией
            string wbLogin = Request.Cookies["wbLogin"];
            if (wbLogin != null && wbLogin != "")
            {
                User user = new User() { Login = wbLogin};
                if (_data.UserCookies(ref user))
                {
                    if (user.Role == "admin")
                    {
                        List<User> listUser = new List<User>();
                        _data.UserAll(ref listUser);
                        ViewBag.user = user;
                        ViewBag.users = listUser;
                        Log log = new Log() { TimeReg = Convert.ToString(DateTime.Now), Message = "AdminPanel", Login = user.Login };
                        _data.LogAdd(log);
                        return View();
                    }
                    return View("NoAccess");
                }
                return View("Access");
            }
            return View("Access");
        }

        [HttpPost]
        public IActionResult SaveUser(User getUser)
        {
            //Стандартная схема загрузки с авторизацией
            string wbLogin = Request.Cookies["wbLogin"];
            if (wbLogin != null && wbLogin != "")
            {
                User user = new User() { Login = wbLogin };
                if (_data.UserCookies(ref user))
                {
                    if (user.Role == "admin")
                    {
                        _data.UserAdd(getUser);
                        List<User> listUser = new List<User>();
                        _data.UserAll(ref listUser);
                        ViewBag.user = user;
                        ViewBag.users = listUser;
                        Log log = new Log() { TimeReg = Convert.ToString(DateTime.Now), Message = "SaveUser", Login = user.Login };
                        _data.LogAdd(log);
                        return View("AdminPanel");
                    }
                    ViewBag.user = user;
                    return View("Index");
                }
                return View("Access");
            }
            return View("Access");
        }

        public IActionResult TegPanel()
        {
            //Стандартная схема загрузки с авторизацией
            string wbLogin = Request.Cookies["wbLogin"];
            if (wbLogin != null && wbLogin != "")
            {
                User user = new User() { Login = wbLogin };
                if (_data.UserCookies(ref user))
                {
                    if (user.Role == "admin" || user.Role == "moder")
                    {
                        List<Teg> listTeg = new List<Teg>();
                        _data.TegList(ref listTeg);
                        ViewBag.user = user;
                        ViewBag.tegs = listTeg;
                        Log log = new Log() { TimeReg = Convert.ToString(DateTime.Now), Message = "TegPanel", Login = user.Login };
                        _data.LogAdd(log);
                        return View();
                    }
                    ViewBag.user = user;
                    return View("Index");
                }
                return View("Access");
            }
            return View("Access");
        }

        [HttpPost]
        public IActionResult SaveTeg(Teg getTeg)
        {
            //Стандартная схема загрузки с авторизацией
            string wbLogin = Request.Cookies["wbLogin"];
            if (wbLogin != null && wbLogin != "")
            {
                User user = new User() { Login = wbLogin };
                if (_data.UserCookies(ref user))
                {
                    if (user.Role == "admin" || user.Role == "moder")
                    {
                        _data.TegAdd(getTeg);
                        List<Teg> listTeg = new List<Teg>();
                        _data.TegList(ref listTeg);
                        ViewBag.user = user;
                        ViewBag.tegs = listTeg;
                        Log log = new Log() { TimeReg = Convert.ToString(DateTime.Now), Message = "SaveTeg", Login = user.Login };
                        _data.LogAdd(log);
                        return View("TegPanel");
                    }
                    ViewBag.user = user;
                    return View("Index");
                }
                return View("Access");
            }
            return View("Access");
        }

        public IActionResult BlogPanel(Blog blog)
        {
            //Стандартная схема загрузки с авторизацией
            string wbLogin = Request.Cookies["wbLogin"];
            if (wbLogin != null && wbLogin != "")
            {
                User user = new User() { Login = wbLogin };
                if (_data.UserCookies(ref user))
                {
                    if (user.Role == "admin" || user.Role == "moder")
                    {
                        if (blog == null || blog.Autor == null || blog.Autor == "") blog = new Blog() { Autor = user.Login, PubDate = Convert.ToString(DateTime.Now)};
                        ViewBag.user = user;
                        ViewBag.blog = blog;
                        List<Teg> listTeg = new List<Teg>();
                        _data.TegList(ref listTeg);
                        ViewBag.tegs = listTeg;
                        Log log = new Log() { TimeReg = Convert.ToString(DateTime.Now), Message = "BlogPanel", Login = user.Login };
                        _data.LogAdd(log);
                        return View();
                    }
                    //ViewBag.user = user;
                    return View("Index");
                }
                return View("Access");
            }
            return View("Access");
        }

        [HttpPost]
        public IActionResult SaveBlogModel(BlogModel blogm)
        {
            //Стандартная схема загрузки с авторизацией
            string wbLogin = Request.Cookies["wbLogin"];
            if (wbLogin != null && wbLogin != "")
            {
                User user = new User() { Login = wbLogin };
                if (_data.UserCookies(ref user))
                {
                    //Запись в базу данных статьи/блога
                    Blog blog = new Blog() { Autor = user.Login, Theme = blogm.Theme, BlogText = blogm.BlogText, PubDate = blogm.PubDate };
                    int i = _data.BlogAdd(blog);
                    //Передача пользователя
                    ViewBag.user = user;
                    //Передача блогов
                    List<Blog> listBlogs = new List<Blog>();
                    _data.BlogAll(ref listBlogs);
                    ViewBag.blogs = listBlogs;
                    //Передача тегов

                    //Передача комментариев
                    List<Comment> listComments = new List<Comment>();
                    _data.CommentsList(ref listComments);
                    ViewBag.listComments = listComments;
                    Log log = new Log() { TimeReg = Convert.ToString(DateTime.Now), Message = "SaveBlogModel", Login = user.Login };
                    _data.LogAdd(log);
                    return View("Index");
                }
                return View("Access");
            }
            return View("Access");
        }

        [HttpPost]
        public IActionResult AddEditComment(IndexSendModel idata)
        {
            //Стандартная схема загрузки с авторизацией
            string wbLogin = Request.Cookies["wbLogin"];
            if (wbLogin != null && wbLogin != "")
            {
                User user = new User() { Login = wbLogin };
                if (_data.UserCookies(ref user))
                {
                    //Добавление комментария
                    if (idata.Id == 1)
                    {
                        Comment comment = new Comment() { SId = idata.IdBlog, Text = idata.Comment, PubDate = Convert.ToString(DateTime.Now), Autor = user.Login };
                        _data.CommentAdd(comment);
                    }
                    //Удаление комментария
                    if (idata.Id == 3)
                    {
                        Comment comment = new Comment() { Id = idata.IdComment, SId = idata.IdBlog, Text = idata.Comment, PubDate = Convert.ToString(DateTime.Now), Autor = user.Login };
                        _data.CommentDel(comment);
                    }
                    //Передача пользователя
                    ViewBag.user = user;
                    //Передача блогов
                    List<Blog> listBlogs = new List<Blog>();
                    _data.BlogAll(ref listBlogs);
                    ViewBag.blogs = listBlogs;
                    //Передача тегов

                    //Передача комментариев
                    List<Comment> listComments = new List<Comment>();
                    _data.CommentsList(ref listComments);
                    ViewBag.listComments = listComments;
                    Log log = new Log() { TimeReg = Convert.ToString(DateTime.Now), Message = "SaveBlogModel", Login = user.Login };
                    _data.LogAdd(log);
                    return View("Index");
                }
                return View("Access");
            }
            return View("Access");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            return View();
        }
    }
}