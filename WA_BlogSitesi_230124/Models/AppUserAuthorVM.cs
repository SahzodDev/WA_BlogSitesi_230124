using WA_BlogSitesi_230124.Entities;

namespace WA_BlogSitesi_230124.Models
{
    public class AppUserAuthorVM
    {
        public AppUser AppUser { get; set; }

        public IEnumerable<Article> Articles { get; set; }

    }
}
