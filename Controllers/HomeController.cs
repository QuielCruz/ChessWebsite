using Microsoft.AspNetCore.Mvc;
using ChessWebsite.Models;

namespace ChessWebsite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
                PageTitle = "Chess Masters - Home",
                HeroTitle = "Ready to Make the Move?",
                HeroSubtitle = "Join tournaments! Enhance your skills and gain experience!",
                Features = new List<Feature>
                {
                    new Feature
                    {
                        Icon = "fas fa-trophy",
                        Title = "Competitive Tournaments",
                        Description = "Join daily, weekly, and monthly tournaments with players of all skill levels to improve your skills."
                    },
                    new Feature
                    {
                        Icon = "fas fa-graduation-cap",
                        Title = "Skill Enhancement",
                        Description = "Gain lessons and tips from chess masters, practice with various opponents, and analyze your games to improve your strategy."
                    },
                    new Feature
                    {
                        Icon = "fas fa-users",
                        Title = "Vibrant Community",
                        Description = "Connect with chess enthusiasts. Discuss strategies and make new friends who share your passion."
                    }
                }
            };

            return View(viewModel);
        }

        public IActionResult Tournaments()
        {
            // Redirect to Tournament controller
            return RedirectToAction("Index", "Tournament");
        }
    }
}