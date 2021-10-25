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
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ISemesterCoreRepository _semesterCoreRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly ITranslationStepRepository _translationStepRepository;
        private readonly IMasteringStepRepository _masteringStepRepository;
        private readonly IMediaTypeRepository _mediaTypeRepository;

        public AdminController(
            ILanguageRepository languageRepository,
            ITranslationStepRepository tranlationStepRepository,
            IMasteringStepRepository masteringStepRepository,
            ISemesterCoreRepository semesterCoreRepository,
            IMediaTypeRepository mediaTypeRepository,
            IOrganizationRepository organizationRepository)
        {
            _languageRepository = languageRepository;
            _translationStepRepository = tranlationStepRepository;
            _masteringStepRepository = masteringStepRepository;
            _semesterCoreRepository = semesterCoreRepository;
            _mediaTypeRepository = mediaTypeRepository;
            _organizationRepository = organizationRepository;

        }

        public IActionResult Users()
        {
            return View();
        }

        //Organization
        public IActionResult Organizations()
        {
            var organizations = _organizationRepository.AllOrganizations;
            return View(organizations);
        }
        
        [HttpPost] 
        //NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        public JsonResult InsertOrgs([FromBody]List<Organization> newOrgs)
        {
            if (newOrgs == null)
            {
                newOrgs = new List<Organization>();
            }

            int insertCount = _organizationRepository.AddOrgs(newOrgs);
            return Json(insertCount);
        }

        [HttpPost]
        public JsonResult UpdateOrg([FromBody] Organization editOrg)
        {
            int updateCount = 0;
            if (editOrg == null)
            {
                editOrg = new Organization();
            }

            EntityState retVal = _organizationRepository.UpdateOrg(editOrg);
            if (retVal == Microsoft.EntityFrameworkCore.EntityState.Modified)
            {
                updateCount = 1;
            }
            return Json(updateCount);
        }

        [HttpPost]
        //NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        public JsonResult DeleteOrgs([FromBody] List<int> delOrglist)
        {
            if (delOrglist == null)
            {
                delOrglist = new List<int>();
            }

            int deleteCount = _organizationRepository.DeleteOrgs(delOrglist);
            return Json(deleteCount);
        }

        [HttpGet]
        public IActionResult OrgDetail(int id)
        {
            //if (id == null)
            //{
            //    // return a bad request
            //    return new BadRequestResult();
            //}

            Organization org = _organizationRepository.GetOrganizationById(id);
            if (org == null)
            {
                return new NotFoundResult();
            }
            return View(org);
        }

            public IActionResult CreateOrganization(Organization newOrg)
        {
            //may need to replace with paramaterized call to SP
            _organizationRepository.AddOrg(newOrg);
            return View(newOrg) ;
        }

        public IActionResult SemesterCores()
        {
            var semesterCores = _semesterCoreRepository.AllSemesterCores;
            return View(semesterCores);
        }

        public IActionResult Languages()
        {
            var languages = _languageRepository.AllLanguages;
            return View(languages);
        }

        public IActionResult TranslationSteps()
        {
            var translationSteps = _translationStepRepository.AllTranslationSteps;
            return View(translationSteps);
        }
        public IActionResult MasteringSteps()
        {
            var masteringSteps = _masteringStepRepository.AllMasteringSteps;
            return View(masteringSteps);
        }

        public IActionResult Payments()
        {
            return View();
        }

        public IActionResult MediaTypes()
        {
            var mediaTypes = _mediaTypeRepository.AllMediaTypes;
            return View(mediaTypes);
        }
    }
}
