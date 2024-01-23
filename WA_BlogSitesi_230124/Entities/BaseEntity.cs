namespace WA_BlogSitesi_230124.Entities
{
    public class BaseEntity
    {
        
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } =  DateTime.Now;
        public string Name { get; set; }
    }
}
