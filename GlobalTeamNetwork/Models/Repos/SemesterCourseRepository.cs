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

        public IEnumerable<DistrSemesterCourse> AllDistrSemesterCourses
        {
            get { return _appDbContext.DistrSemesterCourse; }
        }
        public IEnumerable<DistrSemesterCourse> AllDistrSemesterCoursesShortNotes
        {
            get
            {
                return GTNCommonRepository.TableShortNotes<DistrSemesterCourse>("DistrSemesterCourse", _appDbContext);
            }
        }
    }
}
