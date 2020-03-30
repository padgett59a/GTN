using Microsoft.AspNetCore.Mvc;

namespace GlobalTeamNetwork.Controllers
{
    public class TablesController : Controller
    {
        public IActionResult Basic() => View();
        public IActionResult GenerateStyle() => View();
    }
}
