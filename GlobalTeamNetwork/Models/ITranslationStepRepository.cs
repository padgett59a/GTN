using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public interface ITranslationStepRepository
    {
        IEnumerable<TranslationStep> AllTranslationSteps { get; }
        IEnumerable<TranslationStep> AllTranslationStepsShortNotes { get; }
        TranslationStep GetTranslationStepById(int tsId);
        int InsertTranslationStep(List<TranslationStep> translationStepList);
        int DeleteTranslationStep(List<int> delItemList);
        EntityState UpdateTranslationStep(TranslationStep TranslationStep);
    }
}
