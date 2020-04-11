using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlobalTeamNetwork.Data;

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
    }
}
