using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public class DistrSemesterCourse
    {
        public String LangName { get; set; }
        public Int32 langID { get; set; }
        public string SemesterName { get; set; }
        public string CourseName { get; set; }

        [Key]
        public Int32 courseID { get; set; }
    }
}
