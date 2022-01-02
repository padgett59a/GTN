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
        private readonly ISessionCoreRepository _sessionCoreRepository;

        private readonly int INSTRUCTOR_TYPE = 6;
    public CoresController(
            ICurriculumRepository curriculumRepository,
            ISemesterCoreRepository semesterCoreRepository,
            ICourseCoreRepository courseCoreRepository,
            IPersonsRepository personsRepository,
            ISessionCoreRepository sessionCoreRepository
        )
        {
            _curriculumRepository = curriculumRepository;
            _semesterCoreRepository = semesterCoreRepository;
            _personsRepository = personsRepository;
            _courseCoreRepository = courseCoreRepository;
            _sessionCoreRepository = sessionCoreRepository;
        }



        public IActionResult Curriculum()
        {
            var curriculum = _curriculumRepository.AllCurriculum;
            return View(curriculum);
        }

        [HttpPost]
        //NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        public JsonResult InsertCurriculum([FromBody] List<Curriculum> newCurriculum)
        {
            if (newCurriculum == null)
            {
                newCurriculum = new List<Curriculum>();
            }

            int insertCount = _curriculumRepository.InsertCurriculum(newCurriculum);
            return Json(insertCount);
        }

        [HttpPost]
        //NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        public JsonResult deleteCurriculum([FromBody] List<int> delItemList)
        {
            if (delItemList == null)
            {
                delItemList = new List<int>();
            }

            int deleteCount = _curriculumRepository.DeleteCurriculum(delItemList);
            return Json(deleteCount);
        }

        public JsonResult UpdateCurriculum([FromBody] Curriculum updateItem)
        {
            int updateCount = 0;
            if (updateItem == null)
            {
                updateItem = new Curriculum();
            }

            EntityState retVal = _curriculumRepository.UpdateCurriculum(updateItem);
            if (retVal == Microsoft.EntityFrameworkCore.EntityState.Modified)
            {
                updateCount = 1;
            }
            return Json(updateCount);
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

        public string GetSemestersJson()
        {
            List<SemesterCore> semesterCores = _semesterCoreRepository.AllSemesterCores.OrderBy(s => s.SemesterName).ToList();
            string retVal = JsonConvert.SerializeObject(semesterCores);
            return retVal;
        }

        //******************  CourseCores ************************//

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
        public string GetCoursesJson()
        {
            List<CourseCore> courseCores = _courseCoreRepository.AllCourseCores.OrderBy(c => c.CourseName).ToList();
            string retVal = JsonConvert.SerializeObject(courseCores);
            return retVal;
        }

        public IActionResult SessionCores()
        {
            List<SessionCore> SessionCores = _sessionCoreRepository.AllSessionCores.ToList();
            IEnumerable<SessionCoreCName> SessionCNames = _sessionCoreRepository.ConvertSessionsToCNames(SessionCores).OrderBy(i => i.CourseName).ThenBy(i => i.SessionName);
            return View(SessionCNames);
        }

        [HttpPost]
        //NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        public JsonResult InsertSessions([FromBody] List<SessionCore> newSessions)
        {
            if (newSessions == null)
            {
                newSessions = new List<SessionCore>();
            }

            int insertCount = _sessionCoreRepository.InsertSessions(newSessions);
            return Json(insertCount);
        }

        [HttpPost]
        //NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        public JsonResult deleteSessions([FromBody] List<int> delItemList)
        {
            if (delItemList == null)
            {
                delItemList = new List<int>();
            }

            int deleteCount = _sessionCoreRepository.DeleteSessions(delItemList);
            return Json(deleteCount);
        }

        public JsonResult UpdateSession([FromBody] SessionCore updateItem)
        {
            int updateCount = 0;
            if (updateItem == null)
            {
                updateItem = new SessionCore();
            }

            EntityState retVal = _sessionCoreRepository.UpdateSessionCore(updateItem);
            if (retVal == Microsoft.EntityFrameworkCore.EntityState.Modified)
            {
                updateCount = 1;
            }
            return Json(updateCount);
        }
    }
}
