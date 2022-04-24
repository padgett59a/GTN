using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public interface ILocationRepository
    {
        IEnumerable<Location> AllLocations { get; }
        Location GetLocationById(int langId);
        int InsertLocations(List<Location> languageList);
        int DeleteLocation(List<int> delItemList);
        EntityState UpdateLocation(Location language);
    }
}
