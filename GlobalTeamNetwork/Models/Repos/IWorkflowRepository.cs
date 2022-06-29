using GlobalTeamNetwork.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public interface IWorkflowRepository
    {
        List<TxLog> TranslateLanguage(TxSemester trxSem, ApplicationDbContext dbContext);
        List<TrxStatus> GetTrxStatuses(Int16 @inTrxOnly, ApplicationDbContext dbContext);
        List<TrxStatus> GetMrxStatuses(ApplicationDbContext dbContext);
        List<MxLog> GetMasteringLogs(TxSemester trxSem, ApplicationDbContext dbContext);

        EntityState UpdateTranslationLog(TranslationLog tLog);
        EntityState UpdateMasteringLog(MasteringLog tLog);
        TranslationLog GetTranslationLogById(int tLogID);
        MasteringLog GetMasteringLogById(int mLogID);
        List<DistrSession> GetDistributionSessions(string sessionCoreIDs, ApplicationDbContext dbContext);
        int SaveSessionDistribution(SessionDistLoc pSessDistr);
        string GetNextDistIndex(String pMoYear, ApplicationDbContext dbContext);
        List<SessionDistSetsFull> GetAllSessionDistSetsJoined();
        List<SessionDistFull> GetAllSessionDistJoined();

    }
}
