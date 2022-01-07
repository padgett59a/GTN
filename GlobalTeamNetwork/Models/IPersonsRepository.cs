using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public interface IPersonsRepository
    {
        IEnumerable<Person> AllPersons { get; }
        IEnumerable<Person> AllPersonsShortNotes { get; }
        Person GetPersonById(Int32 personID);
        List<PersonOname> ConvertPersonsToOnames(List<Person> Persons);
        int InsertPersons(List<Person> PersonList);
        int DeletePersons(List<int> delItemList);
        EntityState UpdatePerson(Person Person);

    }
}
