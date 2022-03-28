using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlobalTeamNetwork.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GlobalTeamNetwork.Models
{
    public interface ISemesterCourseRepository 
    {

        public IEnumerable<DistrSemesterCourse> AllDistrSemesterCourses { get; }
        public IEnumerable<DistrSemesterCourse> AllDistrSemesterCoursesShortNotes { get; }

    }
}
