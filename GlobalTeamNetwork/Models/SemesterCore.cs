using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public class SemesterCore
    {
        public string SemesterName { get; set; }
        [Key]
        public string SemesterCode { get; set; }
        public string CurriculumName { get; set; }
        public Int16 NumberOfVideoSessions{ get; set; }
    }
    public class SemesterCoreColId
    {
        public string SemesterName { get; set; }
        [Key]
        public string SemesterCode { get; set; }
        public string CurriculumID { get; set; }
        public Int16 NumberOfVideoSessions { get; set; }
    }
}
