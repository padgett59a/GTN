using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlobalTeamNetwork.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GlobalTeamNetwork.Models
{
    public class PersonsRepository : IPersonsRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public PersonsRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Person> AllPersons
        {
            get { return _appDbContext.Persons.ToList(); }
        }

        public Person GetPersonById(int personID)
        {
            return _appDbContext.Persons.Find(personID);
        }

        //This takes a Person list and coverts it to a PersonOname list 
        public List<PersonOname> ConvertPersonsToOnames(List<Person> Persons)
        {
            //Converts Persons to PersonOnames for easy display
            OrganizationRepository orgRepo = new OrganizationRepository(_appDbContext);
            PersonTypeRepository personTypeRepo = new PersonTypeRepository(_appDbContext);
            List<PersonOname> PersonOnameList = new List<PersonOname>();
            IEnumerable<Organization> orgList = orgRepo.AllOrganizations.ToList();
            IEnumerable<PersonType> personTypeList = personTypeRepo.AllPersonTypes.ToList();
            //IEnumerable<Person> personsList = personsRepo.AllPersons.ToList();

            foreach (Person Person in Persons)
            {
                PersonOname newPersonOname = new PersonOname();

                newPersonOname.personID = Person.personID;
                newPersonOname.FullName = Person.FullName;
                newPersonOname.Phone = Person.Phone;
                newPersonOname.Email = Person.Email;
                newPersonOname.Location = Person.Location;
                newPersonOname.Organization = orgList.First(o => o.orgID == Person.orgID).OrgName;
                newPersonOname.Role = personTypeList.First(pt => pt.personTypeID == Person.personTypeID).PersonTypeName;
                newPersonOname.Location = Person.Location;
                newPersonOname.Notes = Person.Notes;

                PersonOnameList.Add(newPersonOname);
            }
            return PersonOnameList;
        }

        public int InsertPersons(List<Person> PersonList)
        {
            int addCount = 0;
            foreach (Person newItem in PersonList)
            {
                var retVal = _appDbContext.Persons.Add(newItem);
                if (retVal.State == EntityState.Added) { addCount++; }
            }
            _appDbContext.SaveChanges();
            return addCount;
        }

        public int DeletePersons(List<int> delItemList)
        {
            int delCount = 0;
            foreach (int delItemId in delItemList)
            {
                Person delItem = this.GetPersonById(delItemId);
                var retVal = _appDbContext.Persons.Remove(delItem);
                if (retVal.State == EntityState.Deleted) { delCount++; }
            }
            _appDbContext.SaveChanges();
            return delCount;
        }
        public EntityState UpdatePerson(Person Person)
        {
            EntityEntry<Person> retVal = _appDbContext.Persons.Update(Person);
            EntityState updateState = retVal.State;
            _appDbContext.SaveChanges();
            return updateState;
        }

    }
}
