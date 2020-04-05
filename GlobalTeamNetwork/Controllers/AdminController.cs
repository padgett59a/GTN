using Microsoft.AspNetCore.Mvc;

namespace GlobalTeamNetwork.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Users() => View();

        public IActionResult Semesters() => View();

        public IActionResult Languages() => View();

        public IActionResult Payments() => View();

    }
}
