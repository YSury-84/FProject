using System.ComponentModel.DataAnnotations;

namespace WebBlog6.Models
{
    public class AccessModel
    {
        [Required(ErrorMessage = "Необходимо ввести имя")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Необходимо ввести пароль")]
        public string Pass { get; set; }
    }
}
