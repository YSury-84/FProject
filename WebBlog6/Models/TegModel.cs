using System.ComponentModel.DataAnnotations;

namespace WebBlog6.Models
{
    public class TegModel
    {
        [Display(Name = "Имя тега:")]
        [Required(ErrorMessage = "Необходимо ввести Тег")]
        public string TegName { get; set; }
    }
}
