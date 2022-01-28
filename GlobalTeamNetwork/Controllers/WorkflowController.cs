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
        public IActionResult Translation()
        {
            //var trxStatuses = _workflowRepository.GetTrxStatuses(_appDbContext);
            //return View(trxStatuses);
            return View();
        }

        public JsonResult GetTrxStatusJson()
        {
            List<TrxStatus> retVal = _workflowRepository.GetTrxStatuses(_appDbContext);
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

        public IActionResult EditTranslations(string genExams, string semesterCode, string courseCodes, string langID)
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

        //public string GetPersonTypesJson()
        //{
        //    var personTypes = _personTypeRepository.AllPersonTypes;
        //    string retVal = JsonConvert.SerializeObject(personTypes);
        //    return retVal;
        //}


        //[HttpPost]
        ////NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        //public JsonResult InsertWorkflow([FromBody] List<Person> newWorkflow)
        //{
        //    if (newWorkflow == null)
        //    {
        //        newWorkflow = new List<Person>();
        //    }

        //    int insertCount = _personsRepository.InsertWorkflow(newWorkflow);
        //    return Json(insertCount);
        //}

        //[HttpPost]
        ////NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        //public JsonResult deleteWorkflow([FromBody] List<int> delItemList)
        //{
        //    if (delItemList == null)
        //    {
        //        delItemList = new List<int>();
        //    }

        //    int deleteCount = _personsRepository.DeleteWorkflow(delItemList);
        //    return Json(deleteCount);
        //}


        //public string GetWorkflowJson()
        //{
        //    List<Person> persons = _personsRepository.AllWorkflow.OrderBy(p => p.FullName).ToList();
        //    string retVal = JsonConvert.SerializeObject(persons);
        //    return retVal;
        //}

    }
}
