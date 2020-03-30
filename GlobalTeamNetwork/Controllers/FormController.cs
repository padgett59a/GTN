using Microsoft.AspNetCore.Mvc;

namespace GlobalTeamNetwork.Controllers
{
    public class FormController : Controller
    {
        public IActionResult BasicInputs() => View();
        public IActionResult CheckboxRadio() => View();
        public IActionResult Elements() => View();
        public IActionResult InputGroups() => View();
        public IActionResult Validation() => View();
    }
}
