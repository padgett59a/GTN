using GlobalTeamNetwork.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace GlobalTeamNetwork.Controllers
{
    public class OrgController: Controller
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrgController(
            IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }



        //Organization
        public IActionResult Organizations()
        {
            var organizations = _organizationRepository.AllOrganizationsShortNotes;
            return View(organizations);
        }

        public string GetOrganizationsJson()
        {
            var organizations = _organizationRepository.AllOrganizations;
            string retVal = JsonConvert.SerializeObject(organizations);
            return retVal;
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

    }
}
