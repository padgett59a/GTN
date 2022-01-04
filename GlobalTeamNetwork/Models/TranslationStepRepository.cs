using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlobalTeamNetwork.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GlobalTeamNetwork.Models
{
    public class TranslationStepRepository : ITranslationStepRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public TranslationStepRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<TranslationStep> AllTranslationSteps
        {
            get { return _appDbContext.TranslationSteps; }
        }

        public TranslationStep GetTranslationStepById(int tsID)
        {
            return _appDbContext.TranslationSteps.Find(tsID);
        }
        public int InsertTranslationStep(List<TranslationStep> translationStepList)
        {
            int addCount = 0;
            foreach (TranslationStep newItem in translationStepList)
            {
                var retVal = _appDbContext.TranslationSteps.Add(newItem);
                if (retVal.State == EntityState.Added) { addCount++; }
            }
            _appDbContext.SaveChanges();
            return addCount;
        }

        public int DeleteTranslationStep(List<int> delItemList)
        {
            int delCount = 0;
            foreach (int delItemId in delItemList)
            {
                TranslationStep delItem = this.GetTranslationStepById(delItemId);
                var retVal = _appDbContext.TranslationSteps.Remove(delItem);
                if (retVal.State == EntityState.Deleted) { delCount++; }
            }
            _appDbContext.SaveChanges();
            return delCount;
        }
        public EntityState UpdateTranslationStep(TranslationStep TranslationStep)
        {
            EntityEntry<TranslationStep> retVal = _appDbContext.TranslationSteps.Update(TranslationStep);
            EntityState updateState = retVal.State;
            _appDbContext.SaveChanges();
            return updateState;
        }
    }
}
