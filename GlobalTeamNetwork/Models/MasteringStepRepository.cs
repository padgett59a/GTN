using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using GlobalTeamNetwork.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GlobalTeamNetwork.Models
{
    public class MasteringStepRepository : IMasteringStepRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public MasteringStepRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<MasteringStep> AllMasteringSteps 
        {
            get { return _appDbContext.MasteringSteps; }
        }
        public IEnumerable<MasteringStep> AllMasteringStepsShortNotes
        {
            get
            {
                return GTNCommonRepository.TableShortNotes<MasteringStep>("MasteringSteps", _appDbContext);
            }
        }

        public MasteringStep GetMasteringStepById(int msId)
        {
            return _appDbContext.MasteringSteps.Find(msId);
        }
        public int InsertMasteringStep(List<MasteringStep> masteringStepList)
        {
            int addCount = 0;
            foreach (MasteringStep newItem in masteringStepList)
            {
                var retVal = _appDbContext.MasteringSteps.Add(newItem);
                if (retVal.State == EntityState.Added) { addCount++; }
            }
            _appDbContext.SaveChanges();
            return addCount;
        }

        public int DeleteMasteringStep(List<int> delItemList)
        {
            int delCount = 0;
            foreach (int delItemId in delItemList)
            {
                MasteringStep delItem = this.GetMasteringStepById(delItemId);
                var retVal = _appDbContext.MasteringSteps.Remove(delItem);
                if (retVal.State == EntityState.Deleted) { delCount++; }
            }
            _appDbContext.SaveChanges();
            return delCount;
        }
        public EntityState UpdateMasteringStep(MasteringStep MasteringStep)
        {
            EntityEntry<MasteringStep> retVal = _appDbContext.MasteringSteps.Update(MasteringStep);
            EntityState updateState = retVal.State;
            _appDbContext.SaveChanges();
            return updateState;
        }

    }
}
