using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public interface IMasteringStepRepository
    {
        IEnumerable<MasteringStep> AllMasteringSteps { get; }
        MasteringStep GetMasteringStepById(int msId);
    }
}
