using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public class Language
    {
        [Key]
        public int langID { get; set; }
        public string LangName { get; set; }
        public string Notes { get; set; }
    }
}
