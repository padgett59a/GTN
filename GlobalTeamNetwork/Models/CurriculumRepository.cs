using System;
using System.Collections.Generic;
using GlobalTeamNetwork.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
        public IEnumerable<Curriculum> AllCurriculumShortNotes
        {
            get
            {
                return GTNCommonRepository.TableShortNotes<Curriculum>("Curriculums", _appDbContext);
            }
        }

        public Curriculum GetCurriculumById(Int32 curriculumID)
        {
            //may need to replace with paramaterized call to SP
            return _appDbContext.Curriculums.Find(curriculumID);
        }

        public int InsertCurriculum(List<Curriculum> curriculum)
        {
            int addCount = 0;
            foreach (Curriculum newItem in curriculum)
            {
                var retVal = _appDbContext.Curriculums.Add(newItem);
                if (retVal.State == EntityState.Added) { addCount++; }
            }
            _appDbContext.SaveChanges();
            return addCount;
        }
        public int DeleteCurriculum(List<int> delItemList)
        {
            int delCount = 0;
            foreach (int delItemId in delItemList)
            {
                Curriculum delItem = this.GetCurriculumById(delItemId);
                var retVal = _appDbContext.Curriculums.Remove(delItem);
                if (retVal.State == EntityState.Deleted) { delCount++; }
            }
            _appDbContext.SaveChanges();
            return delCount;
        }
        public EntityState UpdateCurriculum(Curriculum Curriculum)
        {
            EntityEntry<Curriculum> retVal = _appDbContext.Curriculums.Update(Curriculum);
            EntityState updateState = retVal.State;
            _appDbContext.SaveChanges();
            return updateState;
        }

    }
}
