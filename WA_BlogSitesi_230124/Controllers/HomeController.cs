using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WA_BlogSitesi_230124.Context;
using WA_BlogSitesi_230124.Entities;
using WA_BlogSitesi_230124.Models;

namespace WA_BlogSitesi_230124.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> userManager;
        private readonly AppDbContext appDbContext;

        public HomeController(ILogger<HomeController> logger,UserManager<AppUser>userManager,AppDbContext appDbContext)
        {
            _logger = logger;
            this.userManager = userManager;
            this.appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            List<Article> mostViewedArticles = appDbContext.Article.OrderByDescending(a => a.ReadCounter).Take(10).Include(a => a.Subject).ToList(); 

            return View(mostViewedArticles);
        }


        public async Task<IActionResult> Index2()
        {
            var mostViewedArticles = appDbContext.Article.OrderByDescending(a => a.ReadCounter).Take(10).Include(a => a.Subject).ToList();

            var userName = HttpContext.User.Identity.Name;

            var currentUser = await userManager.FindByNameAsync(userName);

            var followedSubjectIds = currentUser.FollowedSubjects?.Select(s => s.Id);

            var articlesInFollowedSubjects = appDbContext.Article.Where(a => followedSubjectIds.Contains(a.SubjectId)).ToList();

            var allSubjects = appDbContext.Subject.ToList();

            var followedSubjects = appDbContext.Subject.Where(s => currentUser.FollowedSubjects.Any(f => f.Id == s.Id)).ToList();

            var notFollowedSubjects = appDbContext.Subject.Where(s => !currentUser.FollowedSubjects.Any(f => f.Id == s.Id)).ToList();


            Index2VM index2VM = new Index2VM();
            index2VM.MostViewedArticles = mostViewedArticles;
            index2VM.ArticlesInFollowedSubjects = articlesInFollowedSubjects;
            index2VM.AllSubjects = allSubjects;
            index2VM.FollowedSubjects = followedSubjects;
            index2VM.NonFollowedSubjects = notFollowedSubjects;


            return View(index2VM);
        }

        public async Task<IActionResult> AddSubject()
        {
            var userName = HttpContext.User.Identity.Name;

            var currentUser = await userManager.FindByNameAsync(userName);

            List<Subject> notFollowedSubjects = appDbContext.Subject.Where(s => !currentUser.FollowedSubjects.Any(f => f.Id == s.Id)).ToList();

            return View(notFollowedSubjects);
        }

        [HttpPost]
        public async Task<IActionResult> AddSubject(int id)
        {
            var userName = HttpContext.User.Identity.Name;

            AppUser user = await userManager.FindByNameAsync(userName);

            Subject subject = appDbContext.Subject.Find(id);

            user.FollowedSubjects.ToList().Add(subject);
            appDbContext.SaveChanges();
            return RedirectToAction("AddSubject");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }






































































































































































































































































































































        public async Task<IActionResult> AuthorDetail()
        {
            AppUser user = await userManager.GetUserAsync(HttpContext.User);
            return View(user);
        }
    }
}