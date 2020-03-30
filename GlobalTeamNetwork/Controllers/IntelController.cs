using Microsoft.AspNetCore.Mvc;

namespace GlobalTeamNetwork.Controllers
{
    public class IntelController : Controller
    {
        public IActionResult AnalyticsDashboard() => View();
        public IActionResult BuildNotes() => View();
        public IActionResult Introduction() => View();
        public IActionResult MarketingDashboard() => View();
        public IActionResult Privacy() => View();
    }
}
