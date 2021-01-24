using GlobalTeamNetwork.Models;
using Microsoft.AspNetCore.Mvc;

namespace GlobalTeamNetwork.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly ITranslationStepRepository _translationStepRepository;
        private readonly IMasteringStepRepository _masteringStepRepository;

        public AdminController(ILanguageRepository languageRepository, ITranslationStepRepository tranlationStepRepository, IMasteringStepRepository masteringStepRepository)
        {
            _languageRepository = languageRepository;
            _translationStepRepository = tranlationStepRepository;
            _masteringStepRepository = masteringStepRepository;

        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Semesters()
        {
            return View();
        }

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
        public IActionResult MasteringSteps()
        {
            var masteringSteps = _masteringStepRepository.AllMasteringSteps;
            return View(masteringSteps);
        }

        public IActionResult Payments()
        {
            return View();
        }

        public IActionResult MediaTypes()
        {
            return View();
        }
    }
}
