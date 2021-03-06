using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public interface ISessionDistributionRepository
    {
        IEnumerable<SessionDistribution> AllSessionDistributions { get; }
        EntityState InsertSessionDistribution(SessionDistribution pSessDistSet);
    }
}
