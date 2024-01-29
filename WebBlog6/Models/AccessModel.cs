using System.ComponentModel.DataAnnotations;

namespace WebBlog6.Models
{
    public class AccessModel
    {
        [Display(Name = "Логин:")]
        [Required(ErrorMessage = "Необходимо ввести имя")]
        public string Login { get; set; }
        [Display(Name = "Пароль:")]
        [Required(ErrorMessage = "Необходимо ввести пароль")]
        [StringLength(32,MinimumLength = 4, ErrorMessage = "Необходимо ввести хотя бы 4-ре символа")]
        public string Pass { get; set; }
    }
}
