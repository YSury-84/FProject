using System.ComponentModel.DataAnnotations;

namespace WebBlog6.Models.db
{
    public class Teg
    {
        [Key]
        public string TegName { get; set; }
    }
}
