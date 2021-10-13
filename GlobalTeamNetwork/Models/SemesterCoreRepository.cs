using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlobalTeamNetwork.Data;

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
    }
}
