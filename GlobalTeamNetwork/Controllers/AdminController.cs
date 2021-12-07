using GlobalTeamNetwork.Models;
using GlobalTeamNetwork.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GlobalTeamNetwork.Controllers
{
    public class AdminController : Controller
    {
        //private readonly IOrganizationRepository _organizationRepository;
        private readonly ICurriculumRepository _curriculumRepository;
        private readonly ISemesterCoreRepository _semesterCoreRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly ITranslationStepRepository _translationStepRepository;
        private readonly IMasteringStepRepository _masteringStepRepository;
        private readonly IMediaTypeRepository _mediaTypeRepository;

        public AdminController(
            ILanguageRepository languageRepository,
            ITranslationStepRepository tranlationStepRepository,
            IMasteringStepRepository masteringStepRepository,
            ICurriculumRepository curriculumRepository,
            ISemesterCoreRepository semesterCoreRepository,
            IMediaTypeRepository mediaTypeRepository)
            //IOrganizationRepository organizationRepository)
        {
            _languageRepository = languageRepository;
            _translationStepRepository = tranlationStepRepository;
            _masteringStepRepository = masteringStepRepository;
            _curriculumRepository = curriculumRepository;
            _semesterCoreRepository = semesterCoreRepository;
            _mediaTypeRepository = mediaTypeRepository;
            //_organizationRepository = organizationRepository;

        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Curriculum()
        {
            var curriculum = _curriculumRepository.AllCurriculum;
            return View(curriculum);
        }

        public IActionResult SemesterCores()
        {
            var semesterCores = _semesterCoreRepository.AllSemesterCores;
            return View(semesterCores);
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
            var mediaTypes = _mediaTypeRepository.AllMediaTypes;
            return View(mediaTypes);
        }
    }
}
