using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlobalTeamNetwork.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GlobalTeamNetwork.Models
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public LanguageRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Language> AllLanguages
        {
            get { return _appDbContext.Languages; }
        }

        public Language GetLanguageById(int langId)
        {
            return _appDbContext.Languages.Find(langId);
        }
        public int InsertLanguage(List<Language> languageList)
        {
            int addCount = 0;
            foreach (Language newItem in languageList)
            {
                var retVal = _appDbContext.Languages.Add(newItem);
                if (retVal.State == EntityState.Added) { addCount++; }
            }
            _appDbContext.SaveChanges();
            return addCount;
        }

        public int DeleteLanguage(List<int> delItemList)
        {
            int delCount = 0;
            foreach (int delItemId in delItemList)
            {
                Language delItem = this.GetLanguageById(delItemId);
                var retVal = _appDbContext.Languages.Remove(delItem);
                if (retVal.State == EntityState.Deleted) { delCount++; }
            }
            _appDbContext.SaveChanges();
            return delCount;
        }
        public EntityState UpdateLanguage(Language language)
        {
            EntityEntry<Language> retVal = _appDbContext.Languages.Update(language);
            EntityState updateState = retVal.State;
            _appDbContext.SaveChanges();
            return updateState;
        }






    }
}
