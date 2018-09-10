namespace MeTube.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Models.BindingModels;

    public class UserController : Controller
    {
        private readonly SignInManager<ApplicationUser> signManager;
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(SignInManager<ApplicationUser> signManager,
            UserManager<ApplicationUser> userManager)
        {
            this.signManager = signManager;
            this.userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register() => this.View();

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Username,
                    PasswordHash = model.Password,
                    Email = model.Email
                };

                var result = await this.userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await this.signManager.SignInAsync(user, false);
                    return this.RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        this.ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return this.View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = "")
        {
            var model = new UserLoginBindingModel { ReturnUrl = returnUrl };
            return this.View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                var result = await this.signManager
                    .PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && 
                        this.Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return this.Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return this.RedirectToAction("Index", "Home");
                    }
                }
            }

            this.ModelState.AddModelError("", "Invalid login attempt");
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await this.signManager.SignOutAsync();
            return this.RedirectToAction("Index", "Home");
        }

        public IActionResult Profile()
        {
            var userId = this.userManager.GetUserId(this.HttpContext.User);

            if (userId == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            var user = this.userManager.FindByIdAsync(userId).Result;
            return this.View(user);
        }
    }
}