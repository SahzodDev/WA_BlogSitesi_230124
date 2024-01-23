namespace WA_BlogSitesi_230124.Entities
{
    public class Subject : BaseEntity
    {
        public IEnumerable<Article> Articles { get; set; }
    }
}
