using GlobalTeamNetwork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace GlobalTeamNetwork.Controllers
{
    public class CoresController : Controller
    {
        private readonly ICurriculumRepository _curriculumRepository;
        private readonly ISemesterCoreRepository _semesterCoreRepository;
        private readonly IPersonsRepository _personsRepository;
        private readonly ICourseCoreRepository _courseCoreRepository;

        private readonly int INSTRUCTOR_TYPE = 6;
    public CoresController(
            ICurriculumRepository curriculumRepository,
            ISemesterCoreRepository semesterCoreRepository,
            ICourseCoreRepository courseCoreRepository,
            IPersonsRepository personsRepository
        )
        {
            _curriculumRepository = curriculumRepository;
            _semesterCoreRepository = semesterCoreRepository;
            _personsRepository = personsRepository;
            _courseCoreRepository = courseCoreRepository;
        }



        public IActionResult Curriculum()
        {
            var curriculum = _curriculumRepository.AllCurriculum;
            return View(curriculum);
        }

        //******************  Semesters ************************//
        public string GetCurriculumJson()
        {
            var curriculum = _curriculumRepository.AllCurriculum;
            string retVal = JsonConvert.SerializeObject(curriculum);
            return retVal;
        }

        public IActionResult SemesterCores()
        {
            List<SemesterCore> semesterCores = _semesterCoreRepository.AllSemesterCores.ToList();
            IEnumerable<SemesterCoreCName> semesterCNames = _semesterCoreRepository.ConvertToCNames(semesterCores).OrderBy(i => i.CurriculumName).ThenBy(i => i.SemesterName);
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

            int insertCount = _semesterCoreRepository.InsertSemesters(newSemesters);
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

            int deleteCount = _semesterCoreRepository.DeleteSemesters(delItemList);
            return Json(deleteCount);
        }

        public JsonResult UpdateSemester([FromBody] SemesterCore updateItem)
        {
            int updateCount = 0;
            if (updateItem == null)
            {
                updateItem = new SemesterCore();
            }

            EntityState retVal = _semesterCoreRepository.UpdateSemesterCore(updateItem);
            if (retVal == Microsoft.EntityFrameworkCore.EntityState.Modified)
            {
                updateCount = 1;
            }
            return Json(updateCount);
        }

        //******************  CourseCores ************************//
        public string GetSemestersJson()
        {
            List<SemesterCore> semesterCores = _semesterCoreRepository.AllSemesterCores.OrderBy(s => s.SemesterName).ToList();
            string retVal = JsonConvert.SerializeObject(semesterCores);
            return retVal;
        }

        public string GetInstructorsJson()
        {
            List<Person> instructors = _personsRepository.AllPersons.Where(i => i.personTypeID == INSTRUCTOR_TYPE).ToList();
            string retVal = JsonConvert.SerializeObject(instructors);
            return retVal;
        }
        public IActionResult CourseCores()
        {
            List<CourseCore> CourseCores = _courseCoreRepository.AllCourseCores.ToList();
            IEnumerable<CourseCoreSName> CourseCNames = _courseCoreRepository.ConvertCoursesToSNames(CourseCores).OrderBy(i => i.SemesterName);
            return View(CourseCNames);
        }

        [HttpPost]
        //NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        public JsonResult InsertCourses([FromBody] List<CourseCore> newCourses)
        {
            if (newCourses == null)
            {
                newCourses = new List<CourseCore>();
            }

            int insertCount = _courseCoreRepository.InsertCourses(newCourses);
            return Json(insertCount);
        }

        [HttpPost]
        //NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        public JsonResult deleteCourses([FromBody] List<int> delItemList)
        {
            if (delItemList == null)
            {
                delItemList = new List<int>();
            }

            int deleteCount = _courseCoreRepository.DeleteCourses(delItemList);
            return Json(deleteCount);
        }

        public JsonResult UpdateCourse([FromBody] CourseCore updateItem)
        {
            int updateCount = 0;
            if (updateItem == null)
            {
                updateItem = new CourseCore();
            }

            EntityState retVal = _courseCoreRepository.UpdateCourseCore(updateItem);
            if (retVal == Microsoft.EntityFrameworkCore.EntityState.Modified)
            {
                updateCount = 1;
            }
            return Json(updateCount);
        }
        //******************  SessionCores ************************//
        /* 
        public IActionResult SessionCores()
        {
            List<SessionCore> SessionCores = _SessionCoreRepository.AllSessionCores.ToList();
            IEnumerable<SessionCoreCName> SessionCNames = _SessionCoreRepository.ConvertToCNames(SessionCores).OrderBy(i => i.CurriculumName).ThenBy(i => i.SessionName);
            return View(SessionCNames);
        }

        [HttpPost]
        NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        public JsonResult InsertSessions([FromBody] List<SessionCore> newSessions)
        {
            if (newSessions == null)
            {
                newSessions = new List<SessionCore>();
            }

            int insertCount = _SessionCoreRepository.InsertSessions(newSessions);
            return Json(insertCount);
        }

        [HttpPost]
        NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        public JsonResult deleteSessions([FromBody] List<string> delItemList)
        {
            if (delItemList == null)
            {
                delItemList = new List<string>();
            }

            int deleteCount = _SessionCoreRepository.DeleteSessions(delItemList);
            return Json(deleteCount);
        }

        public JsonResult UpdateSession([FromBody] SessionCore updateItem)
        {
            int updateCount = 0;
            if (updateItem == null)
            {
                updateItem = new SessionCore();
            }

            EntityState retVal = _SessionCoreRepository.UpdateSessionCore(updateItem);
            if (retVal == Microsoft.EntityFrameworkCore.EntityState.Modified)
            {
                updateCount = 1;
            }
            return Json(updateCount);
        }
        */
    }
}
