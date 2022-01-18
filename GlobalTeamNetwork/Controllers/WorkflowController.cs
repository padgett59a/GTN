using GlobalTeamNetwork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace GlobalTeamNetwork.Controllers
{
    public class WorkflowController : Controller
    {
        private readonly IPersonsRepository _personsRepository;
        private readonly IPersonTypeRepository _personTypeRepository;

        public WorkflowController(IPersonsRepository personsRepository, IPersonTypeRepository personTypeRepository)
        {
            _personsRepository = personsRepository;
            _personTypeRepository = personTypeRepository;
        }

        public IActionResult Translation()
        {
            List<Person> persons = _personsRepository.AllPersonsShortNotes.ToList();
            IEnumerable<PersonOname> personOnames = _personsRepository.ConvertPersonsToOnames(persons).OrderBy(p => p.FullName).ThenBy(p => p.Location);
            IEnumerable<PersonOname> translators = personOnames.Where(p => p.Role == "Translator");
            return View(translators);
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

        //public JsonResult UpdatePerson([FromBody] Person updateItem)
        //{
        //    int updateCount = 0;
        //    if (updateItem == null)
        //    {
        //        updateItem = new Person();
        //    }

        //    EntityState retVal = _personsRepository.UpdatePerson(updateItem);
        //    if (retVal == Microsoft.EntityFrameworkCore.EntityState.Modified)
        //    {
        //        updateCount = 1;
        //    }
        //    return Json(updateCount);
        //}

        //public string GetWorkflowJson()
        //{
        //    List<Person> persons = _personsRepository.AllWorkflow.OrderBy(p => p.FullName).ToList();
        //    string retVal = JsonConvert.SerializeObject(persons);
        //    return retVal;
        //}

    }
}
