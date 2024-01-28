using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBlog6.Models.db
{
    public class User
    {
        [Key]
        public string Login { get; set; }
        public string Pass { get; set; }
        public string Fio { get; set; }
        public string RegDate { get; set; }
        public string Role { get; set; }
    }
}
