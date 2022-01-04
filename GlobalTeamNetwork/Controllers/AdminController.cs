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
        
        [HttpPost]
        //NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        public JsonResult InsertTranslationSteps([FromBody] List<TranslationStep> newTranslationStep)
        {
            if (newTranslationStep == null)
            {
                newTranslationStep = new List<TranslationStep>();
            }

            int insertCount = _translationStepRepository.InsertTranslationStep(newTranslationStep);
            return Json(insertCount);
        }

        [HttpPost]
        //NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        public JsonResult deleteTranslationStep([FromBody] List<int> delItemList)
        {
            if (delItemList == null)
            {
                delItemList = new List<int>();
            }

            int deleteCount = _translationStepRepository.DeleteTranslationStep(delItemList);
            return Json(deleteCount);
        }

        public JsonResult UpdateTranslationStep([FromBody] TranslationStep updateItem)
        {
            int updateCount = 0;
            if (updateItem == null)
            {
                updateItem = new TranslationStep();
            }

            EntityState retVal = _translationStepRepository.UpdateTranslationStep(updateItem);
            if (retVal == Microsoft.EntityFrameworkCore.EntityState.Modified)
            {
                updateCount = 1;
            }
            return Json(updateCount);
        }

        //*****************MasteringSteps*****************
        public IActionResult MasteringSteps()
        {
            var masteringSteps = _masteringStepRepository.AllMasteringSteps;
            return View(masteringSteps);
        }

        [HttpPost]
        //NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        public JsonResult InsertMasteringSteps([FromBody] List<MasteringStep> newMasteringStep)
        {
            if (newMasteringStep == null)
            {
                newMasteringStep = new List<MasteringStep>();
            }

            int insertCount = _masteringStepRepository.InsertMasteringStep(newMasteringStep);
            return Json(insertCount);
        }

        [HttpPost]
        //NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        public JsonResult deleteMasteringStep([FromBody] List<int> delItemList)
        {
            if (delItemList == null)
            {
                delItemList = new List<int>();
            }

            int deleteCount = _masteringStepRepository.DeleteMasteringStep(delItemList);
            return Json(deleteCount);
        }
        public JsonResult UpdateMasteringStep([FromBody] MasteringStep updateItem)
        {
            int updateCount = 0;
            if (updateItem == null)
            {
                updateItem = new MasteringStep();
            }

            EntityState retVal = _masteringStepRepository.UpdateMasteringStep(updateItem);
            if (retVal == Microsoft.EntityFrameworkCore.EntityState.Modified)
            {
                updateCount = 1;
            }
            return Json(updateCount);
        }

        //*****************MediaTypes*****************
        public IActionResult MediaTypes()
        {
            var mediaTypes = _mediaTypeRepository.AllMediaTypes;
            return View(mediaTypes);
        }
        [HttpPost]
        //NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        public JsonResult InsertMediaTypes([FromBody] List<MediaType> newMediaType)
        {
            if (newMediaType == null)
            {
                newMediaType = new List<MediaType>();
            }

            int insertCount = _mediaTypeRepository.InsertMediaType(newMediaType);
            return Json(insertCount);
        }

        [HttpPost]
        //NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        public JsonResult deleteMediaType([FromBody] List<int> delItemList)
        {
            if (delItemList == null)
            {
                delItemList = new List<int>();
            }

            int deleteCount = _mediaTypeRepository.DeleteMediaType(delItemList);
            return Json(deleteCount);
        }
        public JsonResult UpdateMediaType([FromBody] MediaType updateItem)
        {
            int updateCount = 0;
            if (updateItem == null)
            {
                updateItem = new MediaType();
            }

            EntityState retVal = _mediaTypeRepository.UpdateMediaType(updateItem);
            if (retVal == Microsoft.EntityFrameworkCore.EntityState.Modified)
            {
                updateCount = 1;
            }
            return Json(updateCount);
        }

        //*****************Payments*****************
        public IActionResult Payments()
        {
            return View();
        }

    }
}
