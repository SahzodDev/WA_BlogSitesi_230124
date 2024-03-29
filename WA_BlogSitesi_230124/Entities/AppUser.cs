﻿using Microsoft.AspNetCore.Identity;

namespace WA_BlogSitesi_230124.Entities
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            List<Article> articles = new List<Article>();
        }

        public string? ImageFile { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Description { get; set; }
        public IEnumerable<Article> Articles { get; set; }

        public IEnumerable<Subject> FollowedSubjects { get; set; }
    }
}
