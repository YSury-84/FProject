using System.ComponentModel.DataAnnotations;

namespace WebBlog6.Models.db
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int SId { get; set; }
        public string Text { get; set; }
        public string PubDate { get; set; }
        public string Autor { get; set; }
    }
}
