using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GlobalTeamNetwork.Models
{
    public interface ICourseCoreRepository
    {
        IEnumerable<CourseCore> AllCourseCores { get; }
        IEnumerable<CourseCore> AllCourseCoreShortNotes { get; }
        CourseCore GetCourseCoreById(int CourseCode);
        EntityEntry<CourseCore> InsertCourseCore(CourseCore CourseCore);
        List<CourseCoreSName> ConvertCoursesToSNames(List<CourseCore> CourseCores);
        int InsertCourses(List<CourseCore> CourseCores);
        int DeleteCourses(List<int> CourseCodes);
        EntityState UpdateCourseCore(CourseCore CourseCore);
    }
}
