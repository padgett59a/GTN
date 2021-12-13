using GlobalTeamNetwork.Models;
using Microsoft.AspNetCore.Mvc;
//using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace GlobalTeamNetwork.Controllers
{
    public class CoresController : Controller
    {
        private readonly ICurriculumRepository _curriculumRepository;
        private readonly ISemesterCoreRepository _SemesterCoreRepository;

        public CoresController(
            ICurriculumRepository curriculumRepository,
            ISemesterCoreRepository SemesterCoreRepository)
        {
            _curriculumRepository = curriculumRepository;
            _SemesterCoreRepository = SemesterCoreRepository;
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
            List<SemesterCore> semesterCores = _SemesterCoreRepository.AllSemesterCores.ToList();
            IEnumerable<SemesterCoreCName> semesterCNames = _SemesterCoreRepository.ConvertToCNames(semesterCores).OrderBy(i => i.CurriculumName).ThenBy(i => i.SemesterName);
            return View(semesterCNames);
        }

        [HttpPost]
        //NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        public JsonResult InsertSemesters ([FromBody] List<SemesterCore> newSemesters)
        {
            if (newSemesters == null)
            {
                newSemesters = new List<SemesterCore>();
            }

            int insertCount = _SemesterCoreRepository.InsertSemesters(newSemesters);
            return Json(insertCount);
        }

        [HttpPost]
        //NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        public JsonResult deleteSemesters([FromBody] List<string> delItemList)
        {
            if (delItemList == null)
            {
                delItemList = new List<string>();
            }

            int deleteCount = _SemesterCoreRepository.DeleteSemesters(delItemList);
            return Json(deleteCount);
        }

    }
}
