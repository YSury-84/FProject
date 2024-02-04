using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using WebBlog6.Models.db;

namespace WebBlog6.Models
{
    public class BlogModel
    {
        [Display(Name = "Идентификатор блога:")]
        [Required(ErrorMessage = "Новый блог")]
        public int Id { get; set; }
        [Display(Name = "Тема блога:")]
        [Required(ErrorMessage = "Тема не должна быть пустой")]
        public string Theme { get; set; }
        [Display(Name = "Содержание блога:")]
        [Required(ErrorMessage = "Содержание не должно быть пустым")]
        public string BlogText { get; set; }
        [Display(Name = "Автор:")]
        public string Autor { get; set; }
        [Display(Name = "Дата создания:")]
        public string PubDate { get; set; }
        [Display(Name = "Список тегов:")]
        public List<Teg> Tegs { get; set; }
    }
}
