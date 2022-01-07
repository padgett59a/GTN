using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace GlobalTeamNetwork.Models
{
    public class SessionCoreCName //Session Object having CourseName (vice CourseCoreID)
    {
        [Key]
        public Int32 SessionCoreID { get; set; }
        public string CourseName { get; set; }
        public string SessionName { get; set; }
        public decimal SessionCode { get; set; }
        public string Notes { get; set; }
    }

    public class SessionCore
    {
        [Key]
        public Int32 SessionCoreID { get; set; }
        public Int32 CourseCoreID { get; set; }
        public string SessionName { get; set; }
        public decimal SessionCode { get; set; }
        public string Notes { get; set; }

        public static explicit operator SessionCore(DbDataReader v)
        {
            throw new NotImplementedException();
        }
    }
}
