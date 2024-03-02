using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WebBlog6.Models.db;
using WebBlog6.Models.Db.Repository;
using WebBlogApi.Model;
using WebBlogApi.Model.Repository;

namespace WebBlogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<UserController> _logger;
        public readonly IDataRepository _data;

        public UserController(ILogger<UserController> logger, IDataRepository data)
        {
            _logger = logger;
            _data = data;
        }

        [HttpGet(Name = "GetUser")]
        public List<User> Get()
        {
            List<User> listUser = new List<User>();
            _data.UserAll(ref listUser);
            return listUser;
        }

        [HttpGet("{userName},{userPass}")]
        public User Get(string userName, string userPass)
        {
            User user = new User();
            user.Login = userName;
            user.Pass = userPass;
            _data.UserAccess(ref user);
            return user;
        }
    }
}