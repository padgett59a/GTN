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
        public List<TrxStatus> GetTrxStatuses(Int16 @inTrxOnly, ApplicationDbContext dbContext)
        {
            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@inTrxOnly",
                            SqlDbType =  System.Data.SqlDbType.Bit,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = inTrxOnly
                        }
                };

            dbContext.Database.SetCommandTimeout(180);
            var retVal = dbContext.Set<TrxStatus>().FromSqlRaw("[dbo].[SP_GetTrxCourses] @inTrxOnly", param);
            return retVal.ToList();
        }

        public List<TrxStatus> GetMrxStatuses(ApplicationDbContext dbContext)
        {
            dbContext.Database.SetCommandTimeout(180);
            //NOTE Type MrxStatus == Type TrxStatus so just re-using TrxStatus here
            var retVal = dbContext.Set<TrxStatus>().FromSqlRaw("[dbo].[SP_GetMrxCourses]");
            return retVal.ToList();
        }

        //takes a TxSemester obj, returns translation-ready TrxLog (with Courses), ExamsTrxLog (might be empty), MasteringLog (with Courses)
        public List<MxLog> GetMasteringLogs(TxSemester trxSem, ApplicationDbContext dbContext)
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
                        }
                };

            //this one can take some time if the db is 'cold'
            dbContext.Database.SetCommandTimeout(120);
            var retVal = dbContext.Set<MxLog>().FromSqlRaw("[dbo].[SP_Mrx_Sem] @langID, @semCode, @corsCodes", param);
            return retVal.ToList();
        }

       public List<DistrSession> GetDistributionSessions(string sessionCoreIDs, ApplicationDbContext dbContext)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@corsCodes",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Input,
                Value = sessionCoreIDs
            };

            //this one can take some time if the db is 'cold'
            dbContext.Database.SetCommandTimeout(120);
            //var retVal = dbContext.Set<DistrSession>().FromSqlRaw("[dbo].[SP_Get_Course_Sessions] @corsCodes, @langID ", param);
            var retVal = dbContext.Set<DistrSession>().FromSqlRaw("[dbo].[SP_Get_Course_Sessions] @corsCodes", param);
            return retVal.ToList();
        }

        //takes a TxSemester obj, returns translation-ready TrxLog (with Courses), ExamsTrxLog (might be empty), MasteringLog (with Courses)
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
            dbContext.Database.SetCommandTimeout(60);
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
        public EntityState UpdateMasteringLog(MasteringLog mLog)
        {
            EntityEntry<MasteringLog> retVal = _appDbContext.MasteringLog.Update(mLog);
            EntityState updateState = retVal.State;
            _appDbContext.SaveChanges();
            return updateState;
        }

        public TranslationLog GetTranslationLogById(int tLogID)
        {
            return _appDbContext.TranslationLog.Find(tLogID);
        }
        public MasteringLog GetMasteringLogById(int mLogID)
        {
            return _appDbContext.MasteringLog.Find(mLogID);
        }
        public int SaveSessionDistribution(SessionDistLoc pSessDistr)
        {
            int addCount = 0;
            //Resolve location
            LocationRepository locRepo = new LocationRepository(_appDbContext);
            Location loc = new Location();
            loc.City = pSessDistr.City;
            loc.State = pSessDistr.State;
            loc.Country = pSessDistr.Country;
            int nLocID = GTNCommonRepository.LocationCoalesce(loc, locRepo);

            SessionDistSetRepository sdsetRepo = new SessionDistSetRepository(_appDbContext);
            SessionDistributionRepository sdRepo = new SessionDistributionRepository(_appDbContext);
            IEnumerable<SessionDistSet> sdsList = sdsetRepo.AllSessionDistSets;

            SessionDistSet newSessDistSet = new SessionDistSet()
            {
                sessionDistID = 0,
                DistMonthYear = pSessDistr.DistrDate,
                mediaTypeIDs = pSessDistr.mediaTypeIDs,
                locID = nLocID,
                ArchiveFormat = pSessDistr.ArchiveType,
                personID = pSessDistr.personID == 0 ? null : pSessDistr.personID,
                Masters = pSessDistr.Masters,
                Notes = pSessDistr.Notes
            };

            SessionDistSet tempDistSet = sdsList.Where(s => s.DistMonthYear == pSessDistr.DistrDate).First();

            //Delete the temp record
            if (sdsetRepo.DeleteSessionDistSet(tempDistSet) != EntityState.Deleted)
            {
                throw new Exception($"The temporary SessionDistubutionSet {pSessDistr.DistrDate} could not be deleted.");
            }


            if (sdsetRepo.InsertSessionDistSet(newSessDistSet) != EntityState.Added)
            {
                throw new Exception($"The SessionDistubutionSet {pSessDistr.DistrDate} could not be added.");
            }
            IEnumerable<SessionDistSet> newSdsList = sdsetRepo.AllSessionDistSets;

            //pickup gen'd sessionDistID
            SessionDistSet newDss = sdsList.Where(sd => sd.DistMonthYear == pSessDistr.DistrDate).First();

            foreach (int nSessionID in pSessDistr.Sessions) {
                SessionDistribution newDist = new SessionDistribution()
                {
                    sessionDistID = newDss.sessionDistID,
                    sessionID = nSessionID,
                };
                EntityState addState = sdRepo.InsertSessionDistribution(newDist);
                if (addState == EntityState.Added) { addCount++; }
                else
                {
                    throw new Exception($"Unable to add Session Distribution for distribution set {newDss.DistMonthYear} for Session {newDist.sessionID}.");
                }

            }
            return addCount;
        }
        public string GetNextDistIndex (String pMoYear, ApplicationDbContext dbContext)
        {
            var paramList = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@mmYear",
                            SqlDbType =  System.Data.SqlDbType.NVarChar,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = pMoYear
                        },
                        new SqlParameter() {
                            ParameterName = "@nextDistIndex",
                            SqlDbType =  System.Data.SqlDbType.NVarChar,
                            Direction = System.Data.ParameterDirection.Output,
                            Size = 16
                        }
            };
            //execute the SP and capture output param
            var retVal = dbContext.Database.ExecuteSqlRaw("EXEC SP_GetNext_SessionDistr @mmYear, @nextDistIndex OUTPUT", paramList);
            return paramList[1].SqlValue.ToString();
        }

    }
    }
