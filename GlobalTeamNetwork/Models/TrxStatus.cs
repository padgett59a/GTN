using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalTeamNetwork.Models
{
    public class TrxStatus
    {
        //This is the type returned from the SP_Trx_Sem stored procedure
        [Key]
        public Int32 lcID { get; set; }
        public String LangName { get; set; }
        public Int32 langID { get; set; }
        public String SemesterName { get; set; }
        public String SemesterCode { get; set; }
        public String CourseName { get; set; }
        public Int32 courseCoreID { get; set; }
        public Boolean InTranslation { get; set; }
        public Decimal? PercentComplete { get; set; }
    }
}
