using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WA_BlogSitesi_230124.Entities;
using WA_BlogSitesi_230124.Models;

namespace WA_BlogSitesi_230124.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IPasswordHasher<AppUser> passwordHasher;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IPasswordHasher<AppUser> passwordHasher)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.passwordHasher = passwordHasher;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            Login login = new Login();
            login.ReturnUrl = returnUrl;
            return View(login);
        }

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Login(Login login)
		{
			if (ModelState.IsValid)
			{
				AppUser appUser = await userManager.FindByEmailAsync(login.Email);

				if (appUser != null)
				{
					await signInManager.SignOutAsync();
					Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(appUser, login.Password, false, false);
					if (result.Succeeded)
					{
						return RedirectToAction("Index");
					}


				}

				ModelState.AddModelError(nameof(login.Email), "Login Failed : Email or password wrong");
			}

			return View(login);
		}

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create(SignUpVM user)
        {
            if (user.Password != user.RepeatPassword)
            {
                ModelState.AddModelError(nameof(user.Password), "Sign Up Failed : Paswords does not match.");
            }

            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
					UserName = user.UserName,
					Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    
                    

                };


                IdentityResult result = await userManager.CreateAsync(appUser, user.Password);

                if (result.Succeeded)
                {
                    

                    return RedirectToAction("Index");
                }

                else
                {
                    foreach (IdentityError item in result.Errors)
                    {
                        ModelState.AddModelError("Create User", $"{item.Code} - {item.Description}");
                    }
                }
            }


            return View(user);
        }


        public async Task<IActionResult> Update(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                SignUpVM vm = new SignUpVM()
                {
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,

                };
                return View(vm);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, string userName, string firstName, string lastName, string email, string password, string passwordRepeat)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                if (!string.IsNullOrEmpty(userName))
                {
                    user.UserName = userName;
                }
                else
                {
                    ModelState.AddModelError("UpdateUser", "Username cannot be empty.");
                }

				if (!string.IsNullOrEmpty(firstName))
				{
					user.FirstName = firstName;
				}
				else
				{
					ModelState.AddModelError("UpdateUser", "First Name cannot be empty.");
				}

				if (!string.IsNullOrEmpty(lastName))
				{
					user.LastName = lastName;
				}
				else
				{
					ModelState.AddModelError("UpdateUser", "Last Name cannot be empty.");
				}

				if (!string.IsNullOrEmpty(email))
                {
                    user.Email = email;
                }
                else
                {
                    ModelState.AddModelError("UpdateUser", "Email cannot be empty");
                }

				if (!string.IsNullOrEmpty(passwordRepeat))
				{
					
				}
				else
				{
					ModelState.AddModelError("UpdateUser", "Repeat password cannot be empty.");
				}

				if (!string.IsNullOrEmpty(password))
				{
                    if (password == passwordRepeat)
                    {
						user.PasswordHash = passwordHasher.HashPassword(user, password);
					}
                    else
                    {
						ModelState.AddModelError("UpdateUser", "First Name cannot be empty.");
					}
					
				}
				else
				{
					ModelState.AddModelError("UpdateUser", "Passwords are not same.");
				}

				

				

                if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        Errors(result);

                    }
                }
            }
            else
            {
                ModelState.AddModelError("UpdateUser", "User Not Found");
            }

			SignUpVM vm = new SignUpVM()
			{
				UserName = user.UserName,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,

			};

			return View(vm);
        }


        public async Task<IActionResult> Index()
		{
			AppUser user = await userManager.GetUserAsync(HttpContext.User);

			return View(user);
		}


		private void Errors(IdentityResult result)
        {
            foreach (IdentityError item in result.Errors)
            {
                ModelState.AddModelError("UpdateUser", $"{item.Code} - {item.Description}");
            }
        }
    }
}
