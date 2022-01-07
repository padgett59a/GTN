using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GlobalTeamNetwork.Models
{
    public interface ICurriculumRepository
    {
        IEnumerable<Curriculum> AllCurriculum { get; }
        IEnumerable<Curriculum> AllCurriculumShortNotes { get; }
        Curriculum GetCurriculumById(Int32 curriculumID);
        int InsertCurriculum(List<Curriculum> curriculum);
        int DeleteCurriculum(List<int> delItemList);
        EntityState UpdateCurriculum(Curriculum Curriculum);
    }

}
