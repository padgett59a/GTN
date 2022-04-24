using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public interface ILanguageRepository
    {
        IEnumerable<Language> AllLanguages { get; }
        IEnumerable<Language> AllLanguagesShortNotes { get; }
        Language GetLanguageById(int langId);
        int InsertLanguage(List<Language> languageList);
        int DeleteLanguage(List<int> delItemList);
        EntityState UpdateLanguage(Language language);
    }
}
