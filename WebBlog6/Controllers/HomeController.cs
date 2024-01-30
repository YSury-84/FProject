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
            string wbLogin = Request.Cookies["wbLogin"];
            if (wbLogin != null && wbLogin != "")
            {
                User user = new User() { Login = wbLogin};
                if (_data.UserCookies(ref user))
                {
                    if (user.Role == "admin")
                    {
                        List<User> lUser = new List<User>();
                        lUser = _data.UserAll(user);
                        ViewBag.user = user;
                        return View();
                    }
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