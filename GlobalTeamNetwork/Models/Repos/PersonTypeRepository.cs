using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using GlobalTeamNetwork.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GlobalTeamNetwork.Models
{
    public class PersonTypeRepository : IPersonTypeRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public PersonTypeRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<PersonType> AllPersonTypes
        {
            get { return _appDbContext.PersonTypes; }
        }

        public PersonType GetPersonTypeById(int id)
        {
            return _appDbContext.PersonTypes.Find(id);
        }

        public int InsertPersonType(List<PersonType> personTypeList)
        {
            int addCount = 0;
            foreach (PersonType newItem in personTypeList)
            {
                var retVal = _appDbContext.PersonTypes.Add(newItem);
                if (retVal.State == EntityState.Added) { addCount++; }
            }
            _appDbContext.SaveChanges();
            return addCount;
        }

        public int DeletePersonType(List<int> delItemList)
        {
            int delCount = 0;
            foreach (int delItemId in delItemList)
            {
                PersonType delItem = this.GetPersonTypeById(delItemId);
                var retVal = _appDbContext.PersonTypes.Remove(delItem);
                if (retVal.State == EntityState.Deleted) { delCount++; }
            }
            _appDbContext.SaveChanges();
            return delCount;
        }
        public EntityState UpdatePersonType(PersonType PersonType)
        {
            EntityEntry<PersonType> retVal = _appDbContext.PersonTypes.Update(PersonType);
            EntityState updateState = retVal.State;
            _appDbContext.SaveChanges();
            return updateState;
        }

    }
}
