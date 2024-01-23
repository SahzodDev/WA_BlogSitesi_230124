using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WA_BlogSitesi_230124.Entities;

namespace WA_BlogSitesi_230124.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Subject> Subject {  get; set; }
        public DbSet<AppUser> Author { get; set; }
        public DbSet<Article> Article { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Subject>().HasData(
                new Subject
                {
                    Id = 1,
                    CreatedDate = DateTime.Now,
                    Name = "Sci-Fi"
                },
                new Subject
                {
                    Id = 2,
                    CreatedDate = DateTime.Now,
                    Name = "Fantasy"
                },
                new Subject
                {
                    Id = 3,
                    CreatedDate = DateTime.Now,
                    Name = "History"
                },
                new Subject
                {
                    Id = 4,
                    CreatedDate = DateTime.Now,
                    Name = "Movies"
                }
                );
            base.OnModelCreating(builder);
        }
    }
}
