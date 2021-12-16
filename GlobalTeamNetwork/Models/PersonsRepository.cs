using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlobalTeamNetwork.Data;

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
    }
}
