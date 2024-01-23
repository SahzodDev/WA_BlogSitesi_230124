using WA_BlogSitesi_230124.Entities;

namespace WA_BlogSitesi_230124.Models
{
    public class Index2VM
    {
        public IEnumerable<Article> MostViewedArticles { get; set; }

        public IEnumerable<Article> ArticlesInFollowedSubjects { get; set;}

        public IEnumerable<Subject> AllSubjects { get; set; }

        public IEnumerable<Subject> FollowedSubjects { get; set; }
        public IEnumerable<Subject> NonFollowedSubjects { get; set; }
    }
}
