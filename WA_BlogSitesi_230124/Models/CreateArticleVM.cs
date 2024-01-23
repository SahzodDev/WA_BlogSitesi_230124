using WA_BlogSitesi_230124.Entities;

namespace WA_BlogSitesi_230124.Models
{
    public class CreateArticleVM
    {
        public CreateArticleVM()
        {
            Subjects = new List<Subject>();
        }
        public string Title { get; set; }
        public string ReadingTime { get; set; }
        public string AuthorId { get; set; }

        public string Content { get; set; }

        public int SubjectId { get; set; }

        public IEnumerable<Subject> Subjects { get; set; }



    }
}
