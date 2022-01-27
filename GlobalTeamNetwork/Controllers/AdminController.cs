using GlobalTeamNetwork.Models;
using GlobalTeamNetwork.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Newtonsoft.Json;

namespace GlobalTeamNetwork.Controllers
{
    public class AdminController : Controller
    {
        private readonly IStatusRepository _statusRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly ITranslationStepRepository _translationStepRepository;
        private readonly IExamTranslationStepRepository _examTranslationStepRepository;
        private readonly IMasteringStepRepository _masteringStepRepository;
        private readonly IMediaTypeRepository _mediaTypeRepository;

        public AdminController(
            IStatusRepository statusRepository,
            ILanguageRepository languageRepository,
            ITranslationStepRepository tranlationStepRepository,
            IExamTranslationStepRepository examTranlationStepRepository,
            IMasteringStepRepository masteringStepRepository,
            IMediaTypeRepository mediaTypeRepository)
        {
            _statusRepository = statusRepository;
            _languageRepository = languageRepository;
            _translationStepRepository = tranlationStepRepository;
            _examTranslationStepRepository = examTranlationStepRepository;
            _masteringStepRepository = masteringStepRepository;
            _mediaTypeRepository = mediaTypeRepository;
        }

        public IActionResult Users()
        {
            return View();
        }

        //*****************Languages*****************
        public IActionResult Languages()
        {
            var languages = _languageRepository.AllLanguagesShortNotes;
            return View(languages);
        }

        public string GetLanguagesJson()
        {
            List<Language> languages = _languageRepository.AllLanguages.OrderBy(l => l.LangName).ToList();
            string retVal = JsonConvert.SerializeObject(languages);
            return retVal;
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
            var translationSteps = _translationStepRepository.AllTranslationStepsShortNotes;
            return View(translationSteps);
        }

        public JsonResult GetTranslationStepsJson()
        {
            var translationSteps = _translationStepRepository.AllTranslationStepsShortNotes;
            //string retVal = JsonConvert.SerializeObject(translationSteps);
            return Json(translationSteps);
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


        //*****************ExamTranslationSteps*****************
        public IActionResult ExamTranslationSteps()
        {
            var examTranslationSteps = _examTranslationStepRepository.AllExamTranslationStepsShortNotes;
            return View(examTranslationSteps);
        }

        [HttpPost]
        //NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        public JsonResult InsertExamTranslationSteps([FromBody] List<ExamTranslationStep> newExamTranslationStep)
        {
            if (newExamTranslationStep == null)
            {
                newExamTranslationStep = new List<ExamTranslationStep>();
            }

            int insertCount = _examTranslationStepRepository.InsertExamTranslationStep(newExamTranslationStep);
            return Json(insertCount);
        }

        [HttpPost]
        //NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        public JsonResult deleteExamTranslationStep([FromBody] List<int> delItemList)
        {
            if (delItemList == null)
            {
                delItemList = new List<int>();
            }

            int deleteCount = _examTranslationStepRepository.DeleteExamTranslationStep(delItemList);
            return Json(deleteCount);
        }

        public JsonResult UpdateExamTranslationStep([FromBody] ExamTranslationStep updateItem)
        {
            int updateCount = 0;
            if (updateItem == null)
            {
                updateItem = new ExamTranslationStep();
            }

            EntityState retVal = _examTranslationStepRepository.UpdateExamTranslationStep(updateItem);
            if (retVal == Microsoft.EntityFrameworkCore.EntityState.Modified)
            {
                updateCount = 1;
            }
            return Json(updateCount);
        }

        //*****************MasteringSteps*****************
        public IActionResult MasteringSteps()
        {
            var masteringSteps = _masteringStepRepository.AllMasteringStepsShortNotes;
            return View(masteringSteps);
        }

        public JsonResult GetMasteringStepsJson()
        {
            var masteringSteps = _masteringStepRepository.AllMasteringStepsShortNotes;
            //string retVal = JsonConvert.SerializeObject(translationSteps);
            return Json(masteringSteps);
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
            var mediaTypes = _mediaTypeRepository.AllMediaTypesShortNotes;
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

        //*****************Statuss*****************
        public IActionResult Statuses()
        {
            var statuss = _statusRepository.AllStatuses;
            return View(statuss);
        }

        public string GetStatusesJson()
        {
            List<Status> statuses = _statusRepository.AllStatuses.ToList();
            string retVal = JsonConvert.SerializeObject(statuses);
            return retVal;
        }

    }
}
