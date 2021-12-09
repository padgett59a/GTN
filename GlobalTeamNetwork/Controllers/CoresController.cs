using GlobalTeamNetwork.Models;
using Microsoft.AspNetCore.Mvc;
//using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GlobalTeamNetwork.Controllers
{
    public class CoresController : Controller
    {
        private readonly ICurriculumRepository _curriculumRepository;
        private readonly ISemesterCoreRepository _semesterCoreRepository;

        public CoresController(
            ICurriculumRepository curriculumRepository,
            ISemesterCoreRepository semesterCoreRepository)
        {
            _curriculumRepository = curriculumRepository;
            _semesterCoreRepository = semesterCoreRepository;
        }

        public IActionResult Curriculum()
        {
            var curriculum = _curriculumRepository.AllCurriculum;
            return View(curriculum);
        }
        public string GetCurriculumJson()
        {
            var curriculum = _curriculumRepository.AllCurriculum;
            string retVal = JsonConvert.SerializeObject(curriculum);
            return retVal;
        }

        public IActionResult SemesterCores()
        {
            var semesterCores = _semesterCoreRepository.AllSemesterCores;
            return View(semesterCores);
        }

        [HttpPost]
        //NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        public JsonResult InsertSemesters ([FromBody] List<SemesterCore> newSemesters)
        {
            if (newSemesters == null)
            {
                newSemesters = new List<SemesterCore>();
            }

            int insertCount = _semesterCoreRepository.InsertSemesters(newSemesters);
            return Json(insertCount);
        }

    }
}
