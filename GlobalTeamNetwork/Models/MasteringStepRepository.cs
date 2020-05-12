using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using GlobalTeamNetwork.Data;

namespace GlobalTeamNetwork.Models
{
    public class MasteringStepRepository : IMasteringStepRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public MasteringStepRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<MasteringStep> AllMasteringSteps 
        {
            get { return _appDbContext.MasteringSteps; }
        }
        public MasteringStep GetMasteringStepById(int msId)
        {
            throw new NotImplementedException();
        }
    }
}
