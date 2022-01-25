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
        List<TrxStatus> GetTrxStatuses(ApplicationDbContext dbContext);
    }
}
