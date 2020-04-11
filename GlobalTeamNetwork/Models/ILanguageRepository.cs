using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public interface ILanguageRepository
    {
        IEnumerable<Language> AllLanguages { get; }
        Language GetLanguageById(int langId);
    }
}
