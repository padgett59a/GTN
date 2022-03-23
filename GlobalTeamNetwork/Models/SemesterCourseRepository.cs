using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlobalTeamNetwork.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GlobalTeamNetwork.Models
{
    public class SemesterCourseRepository : ISemesterCourseRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public SemesterCourseRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<SemesterCourse> AllSemesterCourses
        {
            get { return _appDbContext.SemesterCourse; }
        }
        public IEnumerable<SemesterCourse> AllSemesterCoursesShortNotes
        {
            get
            {
                return GTNCommonRepository.TableShortNotes<SemesterCourse>("SemesterCourses", _appDbContext);
            }
        }
    }
}
