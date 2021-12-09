using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GlobalTeamNetwork.Models
{
    public interface ISemesterCoreRepository
    {
        IEnumerable<SemesterCore> AllSemesterCores { get; }
        SemesterCore GetSemesterCoreById(string semesterCode);
        EntityEntry<SemesterCore> InsertSemesterCore(SemesterCore semesterCore);
        int InsertSemesters(List<SemesterCore> semesterCores);
    }
}
