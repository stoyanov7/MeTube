namespace MeTube.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Models.BindingModels;
    using Models.ViewModels;
    using Services.Contracts;

    public class TubeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ITubeService tubeService;

        public TubeController(UserManager<ApplicationUser> userManager, ITubeService tubeService)
        {
            this.userManager = userManager;
            this.tubeService = tubeService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Upload() => this.View();

        [HttpPost]
        [Authorize]
        public IActionResult Upload(TubeUploadBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                var youTubeId = this.GetYouTubeIdFromLink(model.YouTubeLink);

                if (youTubeId == null)
                {
                    return this.RedirectToAction("Error", "Home");
                }

                var tube = new Tube
                {
                    Title = model.Title,
                    Author = model.Author,
                    Description = model.Description,
                    YouTubeId = youTubeId,
                    UploaderId = this.userManager.GetUserId(this.HttpContext.User)
                };

                this.tubeService.Add(tube);
                return this.RedirectToAction("Details", "Tube", new {id = tube.Id});
            }
            

            return this.View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Details(int id)
        {
            var tube = this.tubeService.FindById(id);

            if (tube == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            tube.Views++;
            this.tubeService.Save();

            var model = new TubeDetailsViewModel
            {
                Title = tube.Title,
                Author = tube.Author,
                Views = tube.Views,
                Description = tube.Description
            };

            return this.View(model);
        }

        private string GetYouTubeIdFromLink(string youTubeLink)
        {
            string youTubeId = null;

            if (youTubeLink.Contains("youtube.com"))
            {
                youTubeId = youTubeLink.Split("?v=")[1];
            }
            else if (youTubeLink.Contains("youtu.be"))
            {
                youTubeId = youTubeLink.Split("/").Last();
            }

            return youTubeId;
        }
    }
}