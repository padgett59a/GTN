using GlobalTeamNetwork.Data;
using GlobalTeamNetwork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GlobalTeamNetwork.Controllers
{
    public class WorkflowController : Controller
    {
        private readonly IPersonsRepository _personsRepository;
        private readonly ITranslationStepRepository _translationStepRepository;
        private readonly IWorkflowRepository _workflowRepository;
        private readonly ApplicationDbContext _appDbContext;

        public WorkflowController(IPersonsRepository personsRepository, IWorkflowRepository workflowRepository, 
            ITranslationStepRepository translationStepRepository, ApplicationDbContext appDbContext)
        {
            _personsRepository = personsRepository;
            _workflowRepository = workflowRepository;
            _translationStepRepository = translationStepRepository;
            _appDbContext = appDbContext;
        }

        //page load
        public IActionResult CreateTranslations()
        {
            return View();
        }
        public IActionResult GetManagedTranslations()
        {
            return View();
        }
        public IActionResult ManageMastering()
        {
            return View();
        }

        //Get all Translation Status for all Courses
        public JsonResult GetTrxStatusJson()
        {
            List<TrxStatus> retVal = _workflowRepository.GetTrxStatuses(0, _appDbContext);
            return Json(retVal);
        }

        //Get all Translation Status for Courses already in Translation
        public JsonResult GetTrxMgmtJson()
        {
            List<TrxStatus> retVal = _workflowRepository.GetTrxStatuses(1, _appDbContext);
            return Json(retVal);
        }

        [HttpPost]
        //NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        public JsonResult trxSemester([FromBody] TxSemester txSem)
        {
            if (txSem == null)
            {
                txSem = new TxSemester();
            }
            List<TxLog> retVal = _workflowRepository.TranslateLanguage(txSem, _appDbContext);
            return Json(retVal);
        }

        public IActionResult EditNewTranslations(string genExams, string semesterCode, string courseCodes, string langID)
        {

            var getTrans = new TxSemester();
            getTrans.GenExams = Int32.Parse(genExams);
            if (semesterCode == null) {
                getTrans.SemesterCode = "";
            }
            else {
                getTrans.SemesterCode = semesterCode;
            } 
            getTrans.CourseCodes = courseCodes;
            getTrans.LangID = Int32.Parse(langID);

            List<TxLog> retVal = _workflowRepository.TranslateLanguage(getTrans, _appDbContext);
            return View(retVal);
        }

        public IActionResult ManageTranslations(string genExams, string semesterCode, string courseCodes, string langID)
        {

            var getTrans = new TxSemester();
            getTrans.GenExams = 0;
            if (semesterCode == null)
            {
                getTrans.SemesterCode = "";
            }
            else
            {
                getTrans.SemesterCode = semesterCode;
            }
            getTrans.CourseCodes = courseCodes;
            getTrans.LangID = Int32.Parse(langID);

            //The underyling SP checks to see if these are already in translation.
            //It should not be possible to request semesters/courses not already in translation when calling this page
            List<TxLog> retVal = _workflowRepository.TranslateLanguage(getTrans, _appDbContext);
            return View(retVal);
        }

        public JsonResult UpdateTranslationLogs([FromBody] List<TranslationLogUpdate> updateItems)
        {
            int updateCount = 0;
            foreach (TranslationLogUpdate updateItem in updateItems)
            {
                var tLog = _workflowRepository.GetTranslationLogById(updateItem.tlID);
                if (updateItem.translatorID != -1) {
                    tLog.translatorID = updateItem.translatorID;
                }
                if (updateItem.statusID != -1)
                {
                    tLog.statusID = updateItem.statusID;
                }
                if (updateItem.Notes != GTN_Globals.VALUE_NOT_SET)
                {
                    tLog.Notes = updateItem.Notes;
                }
                EntityState retVal = _workflowRepository.UpdateTranslationLog(tLog);
                if (retVal == Microsoft.EntityFrameworkCore.EntityState.Modified)
                {
                    updateCount += 1;
                }
            }
            return Json(updateCount);
        }
    }
}
