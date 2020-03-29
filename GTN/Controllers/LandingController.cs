using Microsoft.AspNetCore.Mvc;

namespace GlobalTeamNetwork.Controllers
{
    public class LandingController : Controller
    {
        public IActionResult Page() => View();
    }
}
