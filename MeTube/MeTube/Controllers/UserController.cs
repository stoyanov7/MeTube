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

        public UserController(SignInManager<ApplicationUser> signManager, UserManager<ApplicationUser> userManager)
        {
            this.signManager = signManager;
            this.userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register() => this.View();

        [HttpPost]
        [AllowAnonymous]
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
    }
}