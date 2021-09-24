using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlobalTeamNetwork.Data;

namespace GlobalTeamNetwork.Models
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public UsersRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Person> AllPersons
        {
            get { return _appDbContext.Persons.ToList(); }
        }

        public Person GetPersonById(int personID)
        {
            return _appDbContext.Persons.Find(personID);
        }
    }
}
