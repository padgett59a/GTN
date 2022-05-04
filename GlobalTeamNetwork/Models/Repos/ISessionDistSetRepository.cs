using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public interface ISessionDistSetRepository
    {
        IEnumerable<SessionDistSet> AllSessionDistSets { get; }
        EntityState InsertSessionDistSet(SessionDistSet pSessDistSet);
    }
}
