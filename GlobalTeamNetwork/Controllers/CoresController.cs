using GlobalTeamNetwork.Models;
using GlobalTeamNetwork.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GlobalTeamNetwork.Controllers
{
    public class CoresController : Controller
    {
        private readonly ISemesterCoreRepository _semesterCoreRepository;
        private readonly ICurriculumRepository _curriculumRepository;

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
