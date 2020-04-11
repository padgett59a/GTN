using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public interface ITranslationStepRepository
    {
        IEnumerable<TranslationStep> AllTranslationSteps { get; }
        TranslationStep GetTranslationStepById(int langId);
    }
}
