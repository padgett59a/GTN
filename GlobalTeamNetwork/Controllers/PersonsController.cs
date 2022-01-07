using GlobalTeamNetwork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace GlobalTeamNetwork.Controllers
{
    public class PersonsController : Controller
    {
        private readonly IPersonsRepository _personsRepository;
        private readonly IPersonTypeRepository _personTypeRepository;

        public PersonsController(IPersonsRepository personsRepository, IPersonTypeRepository personTypeRepository)
        {
            _personsRepository = personsRepository;
            _personTypeRepository = personTypeRepository;
        }

        public IActionResult Persons()
        {
            List<Person> persons = _personsRepository.AllPersonsShortNotes.ToList();
            IEnumerable<PersonOname> personOnames = _personsRepository.ConvertPersonsToOnames(persons).OrderBy(p => p.FullName).ThenBy(p => p.Location);
            return View(personOnames);
        }


        public string GetPersonTypesJson()
        {
            var personTypes = _personTypeRepository.AllPersonTypes;
            string retVal = JsonConvert.SerializeObject(personTypes);
            return retVal;
        }


        [HttpPost]
        //NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        public JsonResult InsertPersons([FromBody] List<Person> newPersons)
        {
            if (newPersons == null)
            {
                newPersons = new List<Person>();
            }

            int insertCount = _personsRepository.InsertPersons(newPersons);
            return Json(insertCount);
        }

        [HttpPost]
        //NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        public JsonResult deletePersons([FromBody] List<int> delItemList)
        {
            if (delItemList == null)
            {
                delItemList = new List<int>();
            }

            int deleteCount = _personsRepository.DeletePersons(delItemList);
            return Json(deleteCount);
        }

        public JsonResult UpdatePerson([FromBody] Person updateItem)
        {
            int updateCount = 0;
            if (updateItem == null)
            {
                updateItem = new Person();
            }

            EntityState retVal = _personsRepository.UpdatePerson(updateItem);
            if (retVal == Microsoft.EntityFrameworkCore.EntityState.Modified)
            {
                updateCount = 1;
            }
            return Json(updateCount);
        }

        public string GetPersonsJson()
        {
            List<Person> persons = _personsRepository.AllPersons.OrderBy(p => p.FullName).ToList();
            string retVal = JsonConvert.SerializeObject(persons);
            return retVal;
        }

    }
}
