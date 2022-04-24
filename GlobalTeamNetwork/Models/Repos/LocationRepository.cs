using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlobalTeamNetwork.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GlobalTeamNetwork.Models
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public LocationRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Location> AllLocations
        {
            get { return _appDbContext.Locations; }
        }

        public Location GetLocationById(int langId)
        {
            return _appDbContext.Locations.Find(langId);
        }
        public int InsertLocations(List<Location> locationList)
        {
            int addCount = 0;
            foreach (Location newItem in locationList)
            {
                var retVal = _appDbContext.Locations.Add(newItem);
                if (retVal.State == EntityState.Added) { addCount++; }
            }
            _appDbContext.SaveChanges();
            return addCount;
        }

        public int DeleteLocation(List<int> delItemList)
        {
            int delCount = 0;
            foreach (int delItemId in delItemList)
            {
                Location delItem = this.GetLocationById(delItemId);
                var retVal = _appDbContext.Locations.Remove(delItem);
                if (retVal.State == EntityState.Deleted) { delCount++; }
            }
            _appDbContext.SaveChanges();
            return delCount;
        }
        public EntityState UpdateLocation(Location location)
        {
            EntityEntry<Location> retVal = _appDbContext.Locations.Update(location);
            EntityState updateState = retVal.State;
            _appDbContext.SaveChanges();
            return updateState;
        }






    }
}
