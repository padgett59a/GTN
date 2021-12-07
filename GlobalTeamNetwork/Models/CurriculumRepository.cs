using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlobalTeamNetwork.Data;

namespace GlobalTeamNetwork.Models
{
    public class CurriculumRepository : ICurriculumRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public CurriculumRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Curriculum> AllCurriculum

        {
            get
            {
                return _appDbContext.Curriculums;
            }
        }

        public Curriculum GetCurriculumById(Int32 curriculumID)
        {
            //may need to replace with paramaterized call to SP
            return _appDbContext.Curriculums.Find(curriculumID);
        }
    }
}
