using Microsoft.AspNetCore.Mvc;

namespace GlobalTeamNetwork.Controllers
{
    public class AspNetCoreController : Controller
    {
        public IActionResult Introduction() => View();
        public IActionResult GettingStarted() => View();
        public IActionResult Editions() => View();
        public IActionResult Settings() => View();
        public IActionResult Faq() => View();
    }
}
