using GlobalTeamNetwork.Models;
using Microsoft.AspNetCore.Mvc;

namespace GlobalTeamNetwork.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly ITranslationStepRepository _translationStepRepository;

        public AdminController(ILanguageRepository languageRepository, ITranslationStepRepository tranlationStepRepository)
        {
            _languageRepository = languageRepository;
            _translationStepRepository = tranlationStepRepository;
        }

        public IActionResult Users() => View();

        public IActionResult Semesters() => View();

        public IActionResult Languages()
        {
            var languages = _languageRepository.AllLanguages;
            return View(languages);
        }

        public IActionResult TranslationSteps()
        {
            var translationSteps = _translationStepRepository.AllTranslationSteps;
            return View(translationSteps);
        }

        public IActionResult Payments() => View();

    }
}
