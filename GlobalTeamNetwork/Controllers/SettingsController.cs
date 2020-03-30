using Microsoft.AspNetCore.Mvc;

namespace GlobalTeamNetwork.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult HowItWorks() => View();
        public IActionResult LayoutOptions() => View();
        public IActionResult SavingDb() => View();
        public IActionResult SkinOptions() => View();
    }
}
