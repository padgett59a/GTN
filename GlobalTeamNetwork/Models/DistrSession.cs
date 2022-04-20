using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalTeamNetwork.Models
{
    public class DistrSession
    {
        //This is the type returned from the SP_Trx_Sem stored procedure
        [Key]
        public Int64 dsID { get; set; }
        public String LangName { get; set; }
        public Int32 langID { get; set; }
        public String SemesterName { get; set; }
        public String CourseName { get; set; }
        public Int32 courseID { get; set; }
        public String SessionName { get; set; }
        public Int32 sessionID { get; set; }
    }
}
