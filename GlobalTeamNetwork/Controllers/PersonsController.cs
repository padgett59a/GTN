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
        private readonly ILocationRepository _locationRepository;
        private readonly IPersonTypeRepository _personTypeRepository;

        public PersonsController(IPersonsRepository personsRepository, IPersonTypeRepository personTypeRepository, ILocationRepository locationRepository)
        {
            _personsRepository = personsRepository;
            _personTypeRepository = personTypeRepository;
            _locationRepository = locationRepository;
        }

        public IActionResult Persons()
        {
            List<Person> persons = _personsRepository.AllPersonsShortNotes.ToList();
            //Do not return system records [Not Started] for each personType. These records have personIDs < 10.
            IEnumerable<PersonOname> personOnames = _personsRepository.ConvertPersonsToOnames(persons).Where(p => p.personID > 9).OrderBy(p => p.FullName).ThenBy(p => p.City);
            return View(personOnames);
        }

        public JsonResult GetTranslatorsJson()
        {
            List<Person> persons = _personsRepository.AllPersonsShortNotes.ToList();
            var retVal = persons.Where(p => p.personTypeID == GTN_Globals.TRANSLATORTYPE).OrderBy(p => p.FullName).ThenBy(p => p.locID);
            return Json(retVal);
        }
        public JsonResult GetMasterersJson()
        {
            List<Person> persons = _personsRepository.AllPersonsShortNotes.ToList();
            var retVal = persons.Where(p => p.personTypeID == GTN_Globals.MASTERERTYPE).OrderBy(p => p.FullName).ThenBy(p => p.locID);
            return Json(retVal);
        }

        public JsonResult GetCustomersJson()
        {
            List<Person> persons = _personsRepository.AllPersonsShortNotes.ToList();
            var retVal = persons.Where(p => p.personTypeID == GTN_Globals.CUSTOMERTYPE).OrderBy(p => p.FullName).ThenBy(p => p.locID);
            return Json(retVal);
        }
        public string GetPersonTypesJson()
        {
            var personTypes = _personTypeRepository.AllPersonTypes;
            string retVal = JsonConvert.SerializeObject(personTypes);
            return retVal;
        }


        [HttpPost]
        //NOTE: FromBody is a REQUIRED attribute for this to retrieve the data from the POST payload
        public JsonResult InsertPersons([FromBody] List<PersonOname> newPersons)
        {
            if (newPersons == null)
            {
                newPersons = new List<PersonOname>();
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

        public JsonResult UpdatePerson([FromBody] PersonOname updateItem)
        {
            int updateCount = 0;
            if (updateItem == null)
            {
                updateItem = new PersonOname();
            }
            Person updatePerson = _personsRepository.ConvertOnameToPerson(updateItem);
            EntityState retVal = _personsRepository.UpdatePerson(updatePerson);
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
        public JsonResult GetLocationsJson()
        {
            List<Location> locations = _locationRepository.AllLocations.ToList();
            var retVal = locations;
            return Json(retVal);
        }

    }
}
