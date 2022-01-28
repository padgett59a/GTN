using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlobalTeamNetwork.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Data.SqlClient;

namespace GlobalTeamNetwork.Models
{
    public class WorkflowRepository : IWorkflowRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public WorkflowRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //Gets all Course/Languages and shows which are in translation
        public List<TrxStatus> GetTrxStatuses(ApplicationDbContext dbContext)
        {
            var retVal = dbContext.Set<TrxStatus>().FromSqlRaw("[dbo].[SP_GetUnTrxCourses]" );
            return retVal.ToList();
        }

        //takes a TxSemester obj, returns translation ready TrxLog (with Courses), ExamsTrxLog (might be empty), MasteringLog (with Courses)
        public List<TxLog> TranslateLanguage(TxSemester trxSem, ApplicationDbContext dbContext)
        {
            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@langID",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = trxSem.LangID
                        },
                        new SqlParameter() {
                            ParameterName = "@semCode",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = trxSem.SemesterCode
                        },
                        new SqlParameter() {
                            ParameterName = "@corsCodes",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = trxSem.CourseCodes
                        },
                        new SqlParameter() {
                            ParameterName = "@genExams",
                            SqlDbType =  System.Data.SqlDbType.Bit,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = trxSem.GenExams
                        }
                };
            
            //this one can take some time if the db is 'cold'
            dbContext.Database.SetCommandTimeout(120);
            var retVal = dbContext.Set<TxLog>().FromSqlRaw("[dbo].[SP_Trx_Sem] @langID, @semCode, @corsCodes, @genExams", param);
            return retVal.ToList();
        }

        

        public EntityState UpdateTranslationLog(TranslationLog tLog)
        {
            EntityEntry<TranslationLog> retVal = _appDbContext.TranslationLog.Update(tLog);
            EntityState updateState = retVal.State;
            _appDbContext.SaveChanges();
            return updateState;
        }

        public TranslationLog GetTranslationLogById(int tLogID)
        {
            return _appDbContext.TranslationLog.Find(tLogID);
        }
    }
}
