using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public interface ICurriculumRepository
    {
        IEnumerable<Curriculum> AllCurriculum { get; }
        Curriculum GetCurriculumById(Int32 curriculumID);
    }
}
