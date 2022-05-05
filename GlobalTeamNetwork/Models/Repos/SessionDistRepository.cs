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
    public class SessionDistributionRepository : ISessionDistributionRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public SessionDistributionRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            //_appDbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public IEnumerable<SessionDistribution> AllSessionDistributions
        {
            get
            {
                return _appDbContext.SessionDist;
            }
        }

        public EntityState InsertSessionDistribution(SessionDistribution pSessDistSet)
        {
            var retVal = _appDbContext.SessionDist.Add(pSessDistSet).State;
            if (retVal == EntityState.Added) { _appDbContext.SaveChanges(); }
            return retVal;
        }

    }
}
