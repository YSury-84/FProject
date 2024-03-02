using Microsoft.AspNetCore.Mvc;
using WebBlog6.Models.db;
using WebBlog6.Models.Db.Repository;
using WebBlogApi.Model;

namespace WebBlogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TegController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        public readonly IDataRepository _data;

        public TegController(ILogger<UserController> logger, IDataRepository data)
        {
            _logger = logger;
            _data = data;
        }

        [HttpGet(Name = "GetTegList")]
        public List<Teg> Get()
        {
            List<Teg> listTeg = new List<Teg>();
            _data.TegList(ref listTeg);
            return listTeg;
        }
    }
}
