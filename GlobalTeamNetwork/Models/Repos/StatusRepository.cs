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
    public class StatusRepository : IStatusRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public StatusRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Status> AllStatuses
        {
            get
            {
                return _appDbContext.Statuses;
            }
        }
    }
}
