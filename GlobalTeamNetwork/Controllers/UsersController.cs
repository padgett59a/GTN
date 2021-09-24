using GlobalTeamNetwork.Models;
using Microsoft.AspNetCore.Mvc;

namespace GlobalTeamNetwork.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersRepository _userRepository;

        public UsersController(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Persons()
        {
            var users = _userRepository.AllPersons;
            return View(users);
        }
    }
}
