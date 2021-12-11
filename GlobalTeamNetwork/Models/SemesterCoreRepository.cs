using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlobalTeamNetwork.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GlobalTeamNetwork.Models
{
    public class SemesterCoreRepository : ISemesterCoreRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public SemesterCoreRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<SemesterCore> AllSemesterCores
        {
            //get { return _appDbContext.SemesterCores; }
            get
            {
                return _appDbContext.SemesterCores.FromSqlRaw("SP_GetSemesterCores");
            }
        }

        public SemesterCore GetSemesterCoreById(string semesterCode)
        {
            //may need to replace with paramaterized call to SP
            return _appDbContext.SemesterCores.Find(semesterCode);
        }
        public EntityEntry<SemesterCore> InsertSemesterCore(SemesterCore semesterCore)
        {
            //may need to replace with paramaterized call to SP
            return _appDbContext.SemesterCores.Add(semesterCore);
        }

        //This takes a semesterCore list having curriculum names (rather than curriculumID). The SP makes the conversion to curriculumID (if it can)
        public int InsertSemesters(List<SemesterCore> semesterCores)
        {
            int addCount = 0;
            foreach (SemesterCore newSemester in semesterCores)
            {
                var retVal = _appDbContext.Database.ExecuteSqlRaw("dbo.SP_InsertSemesterCore {0},{1},{2},{3}", 
                    newSemester.SemesterCode, 
                    newSemester.SemesterName, 
                    newSemester.CurriculumName, 
                    newSemester.NumberOfVideoSessions);
                if (retVal == -1) { addCount++; }
            }
            _appDbContext.SaveChanges();
            return addCount;
        }
        public int DeleteSemesters(List<string> delItemList)
        {
            int delCount = 0;
            foreach (string delItemId in delItemList)
            {
                var retVal = _appDbContext.Database.ExecuteSqlRaw("dbo.SP_DeleteSemesterCoreById {0}",
                    delItemId);
                if (retVal == -1) { delCount++; }
            }
            _appDbContext.SaveChanges();
            return delCount;
        }

        int UpdateSemesters(List<SemesterCore> semesterCodes);

    }
}
