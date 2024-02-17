using System.ComponentModel.DataAnnotations;

namespace WebBlog6.Models.Db
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public string TimeReg { get; set; }
        public string Login { get; set; }
        public string Message { get; set; }
    }
}
