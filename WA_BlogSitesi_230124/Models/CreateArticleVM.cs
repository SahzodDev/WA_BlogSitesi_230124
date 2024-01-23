using WA_BlogSitesi_230124.Entities;

namespace WA_BlogSitesi_230124.Models
{
    public class CreateArticleVM
    {
        public string Title { get; set; }
        public string ReadingTime { get; set; }
        public AppUser Author { get; set; }
        public Subject Subject { get; set; }

        
    }
}
