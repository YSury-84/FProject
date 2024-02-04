namespace WebBlog6.Models.db
{
    public class Blog
    {
        public int Id { get; set; }
        public string Theme { get; set; }
        public string BlogText { get; set; }
        public string Autor { get; set; }
        public string PubDate { get; set; }
    }
}
