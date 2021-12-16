using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public interface IPersonsRepository
    {
        IEnumerable<Person> AllPersons { get; }
        Person GetPersonById(Int32 personID);
    }
}
