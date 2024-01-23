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
            return View();
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
            List<Article>articlesOfUser=appDbContext.Article.Where(a=>a.AppUserId==user.Id).ToList();
            AppUserAuthorVM authorVM = new AppUserAuthorVM()
            {
                AppUser = user,
                Articles = articlesOfUser,
            };
            return View(authorVM);
        }





















































































































































































































































































































































































































































        public async Task<IActionResult> GetArticle()
        {
            // Makaleler  yazarlarıyla birlikte görüntülencek
            List<Article> articles = appDbContext.Article.Include(a=>a.Author).ToList();
            return View(articles);
        }

        public async Task<IActionResult> AddArticle()
        {
            
            CreateArticleVM createArticleVM=new CreateArticleVM();
            AppUser user = await userManager.GetUserAsync(HttpContext.User);
            createArticleVM.Author = user;
            createArticleVM.Subjects=appDbContext.Subject.ToList();

            // kullanıcı bulundu
            // bulunan kullanıcı view kısmına gönderildi.
            // view kısmına gönderme sebebi yazar olarak girilecek inputun dolu olması.
               
            
            return View(createArticleVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddArticle(CreateArticleVM createArticleVM)
        {
            Article article = new Article()
            {
                AppUserId = createArticleVM.AuthorId,
                ReadingTime = createArticleVM.ReadingTime,
                SubjectId = createArticleVM.SubjectId,
                Name = createArticleVM.Title

            };

            // article VM olacak.
            //article nesnesine eşitlenecek
            //db eklenecek . değişiklikler kaydedilecek.
            appDbContext.Article.Add(article);
            appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> ReadArticle(string id)
        {
            //makale açılacak VM olarak görüntülenecek.
            //action tetiklendikçe sayaç 1 artacak.
            Article article = appDbContext.Article.Find(id);
            article.ReadCounter += 1;

            return View(article);
        }










    }
}