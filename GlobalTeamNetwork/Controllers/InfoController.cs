using Microsoft.AspNetCore.Mvc;

namespace GlobalTeamNetwork.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult AppDocs() => View();
        public IActionResult AppFlavors() => View();
        public IActionResult AppLicensing() => View();
    }
}
