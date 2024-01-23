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
    }
}
