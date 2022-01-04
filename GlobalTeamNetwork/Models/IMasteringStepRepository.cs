using Microsoft.EntityFrameworkCore;
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
        int InsertMasteringStep(List<MasteringStep> masteringStepList);

        int DeleteMasteringStep(List<int> delItemList);
        EntityState UpdateMasteringStep(MasteringStep MasteringStep);

    }
}
