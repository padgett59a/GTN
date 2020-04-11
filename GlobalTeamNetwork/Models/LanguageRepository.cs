using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlobalTeamNetwork.Data;

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
    }
}
