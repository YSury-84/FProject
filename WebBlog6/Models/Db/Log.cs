using System.ComponentModel.DataAnnotations;

namespace WebBlog6.Models.Db
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public string DT { get; set; }
        public string Login { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
    }
}
