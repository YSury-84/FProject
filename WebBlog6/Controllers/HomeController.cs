using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebBlog6.Models;
using WebBlog6.Models.db;
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
                    ViewBag.user = user;
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
                                ViewBag.user = people;
                                return View();
                            }
                        }
                        else
                        {
                            getuser.RegDate = Convert.ToString(DateTime.Now);
                            getuser.Role = "user";
                            //Регистрация нового пользователя
                            _data.UserAdd(getuser);
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
            return View();
        }

        public IActionResult About()
        {
            //Сброс авторизации
            Response.Cookies.Append("wbLogin", "");
            //Авторизация не требуется
            return View();
        }

        public IActionResult Register()
        {
            //Авторизация не требуется
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
                        return View();
                    }
                    return View("Index");
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
                        return View("AdminPanel");
                    }
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
                        return View();
                    }
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
                        return View("TegPanel");
                    }
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
                        return View();
                    }
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

                    ViewBag.user = user;
                    return View("Index");
                }
                return View("Access");
            }
            return View("Access");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}