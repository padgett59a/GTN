using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public interface ISemesterCoreRepository
    {
        IEnumerable<SemesterCore> AllSemesterCores { get; }
        SemesterCore GetSemesterCoreById(string semesterCode);
    }
}
