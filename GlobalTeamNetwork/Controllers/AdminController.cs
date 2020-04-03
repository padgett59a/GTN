using Microsoft.AspNetCore.Mvc;

namespace GlobalTeamNetwork.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Users() => View();

        public IActionResult Courses() => View();

        public IActionResult Languages() => View();

        public IActionResult Payments() => View();

    }
}
