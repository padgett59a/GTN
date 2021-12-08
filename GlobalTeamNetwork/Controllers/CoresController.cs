using GlobalTeamNetwork.Models;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult SemesterCores()
        {
            var semesterCores = _semesterCoreRepository.AllSemesterCores;
            return View(semesterCores);
        }
    }
}
