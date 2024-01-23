using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            return View(user);
        }
    }
}