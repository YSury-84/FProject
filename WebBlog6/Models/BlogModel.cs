using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using WebBlog6.Models.db;
using WebBlog6.Models.Db.Repository;

namespace WebBlog6.Models
{
    public class BlogModel
    {
        private readonly IDataRepository _data;

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

        public BlogModel(IDataRepository data)
        {
            List<Teg> Tegs = new List<Teg>();
            _data = data;
            _data.TegList(ref Tegs);
        }
    }
}
