using System.Security.Cryptography.X509Certificates;

namespace WA_BlogSitesi_230124.Entities
{
    public class Article : BaseEntity
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ReadingTime { get; set; }
        public int? ReadCounter { get; set; } = 0;
        public AppUser? Author { get; set; }
        public string? AppUserId { get; set; }
        public Subject Subject { get; set; }
        public int SubjectId { get; set; }
    }
}
