using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public class Curriculum
    {
        public Int32 CurriculumID { get; set; }
        [Key]
        public string CurriculumName { get; set; }
    }
}
