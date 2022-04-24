using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlobalTeamNetwork.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GlobalTeamNetwork.Models
{
    public class ExamTranslationStepRepository : IExamTranslationStepRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public ExamTranslationStepRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<ExamTranslationStep> AllExamTranslationSteps
        {
            get { return _appDbContext.ExamTranslationSteps; }
        }
        public IEnumerable<ExamTranslationStep> AllExamTranslationStepsShortNotes
        {
            get
            {
                return GTNCommonRepository.TableShortNotes<ExamTranslationStep>("ExamTranslationSteps", _appDbContext);
            }
        }

        public ExamTranslationStep GetExamTranslationStepById(int tsID)
        {
            return _appDbContext.ExamTranslationSteps.Find(tsID);
        }
        public int InsertExamTranslationStep(List<ExamTranslationStep> examExamTranslationStepList)
        {
            int addCount = 0;
            foreach (ExamTranslationStep newItem in examExamTranslationStepList)
            {
                var retVal = _appDbContext.ExamTranslationSteps.Add(newItem);
                if (retVal.State == EntityState.Added) { addCount++; }
            }
            _appDbContext.SaveChanges();
            return addCount;
        }

        public int DeleteExamTranslationStep(List<int> delItemList)
        {
            int delCount = 0;
            foreach (int delItemId in delItemList)
            {
                ExamTranslationStep delItem = this.GetExamTranslationStepById(delItemId);
                var retVal = _appDbContext.ExamTranslationSteps.Remove(delItem);
                if (retVal.State == EntityState.Deleted) { delCount++; }
            }
            _appDbContext.SaveChanges();
            return delCount;
        }
        public EntityState UpdateExamTranslationStep(ExamTranslationStep ExamTranslationStep)
        {
            EntityEntry<ExamTranslationStep> retVal = _appDbContext.ExamTranslationSteps.Update(ExamTranslationStep);
            EntityState updateState = retVal.State;
            _appDbContext.SaveChanges();
            return updateState;
        }
    }
}
