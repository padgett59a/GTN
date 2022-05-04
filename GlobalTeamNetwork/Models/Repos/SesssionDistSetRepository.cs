using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlobalTeamNetwork.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;

namespace GlobalTeamNetwork.Models
{
    public class SessionDistSetRepository : ISessionDistSetRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public SessionDistSetRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<SessionDistSet> AllSessionDistSets
        {
            get
            {
                return _appDbContext.SessionDistSets;
            }
        }

        public EntityState InsertSessionDistSet(SessionDistSet pSessDistSet)
        {
            var retVal = _appDbContext.SessionDistSets.Add(pSessDistSet).State;
            if (retVal == EntityState.Added) { _appDbContext.SaveChanges(); }
            return retVal;
        }

    }
}
