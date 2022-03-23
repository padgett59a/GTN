using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public class SemesterCourse
    {
        public string CourseName { get; set; }
        public string SemesterName { get; set; }

        [Key]
        public Int32 courseCoreID { get; set; }
    }
}
