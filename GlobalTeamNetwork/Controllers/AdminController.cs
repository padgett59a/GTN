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
        private readonly ILanguageRepository _languageRepository;
        private readonly ITranslationStepRepository _translationStepRepository;
        private readonly IMasteringStepRepository _masteringStepRepository;
        private readonly IMediaTypeRepository _mediaTypeRepository;

        public AdminController(
            ILanguageRepository languageRepository,
            ITranslationStepRepository tranlationStepRepository,
            IMasteringStepRepository masteringStepRepository,
            IMediaTypeRepository mediaTypeRepository)
        {
            _languageRepository = languageRepository;
            _translationStepRepository = tranlationStepRepository;
            _masteringStepRepository = masteringStepRepository;
            _mediaTypeRepository = mediaTypeRepository;
        }

        public IActionResult Users()
        {
            return View();
        }

        //*****************TranslationSteps*****************
        public IActionResult Languages()
        {
            var languages = _languageRepository.AllLanguages;
            return View(languages);
        }

        [HttpPost]
        //NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        public JsonResult InsertLanguages([FromBody] List<Language> newLanguage)
        {
            if (newLanguage == null)
            {
                newLanguage = new List<Language>();
            }

            int insertCount = _languageRepository.InsertLanguage(newLanguage);
            return Json(insertCount);
        }

        [HttpPost]
        //NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        public JsonResult deleteLanguage([FromBody] List<int> delItemList)
        {
            if (delItemList == null)
            {
                delItemList = new List<int>();
            }

            int deleteCount = _languageRepository.DeleteLanguage(delItemList);
            return Json(deleteCount);
        }

        public JsonResult UpdateLanguage([FromBody] Language updateItem)
        {
            int updateCount = 0;
            if (updateItem == null)
            {
                updateItem = new Language();
            }

            EntityState retVal = _languageRepository.UpdateLanguage(updateItem);
            if (retVal == Microsoft.EntityFrameworkCore.EntityState.Modified)
            {
                updateCount = 1;
            }
            return Json(updateCount);
        }


        //*****************TranslationSteps*****************
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
