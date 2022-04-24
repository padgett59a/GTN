using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public interface IUsersRepository
    {
        List<Person> AllPersons { get; }
        Person GetPersonById(int personID);
    }
}
