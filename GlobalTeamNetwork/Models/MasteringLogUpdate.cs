using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalTeamNetwork.Models
{
    public class MasteringLogUpdate
    {
        [Key] 
        public Int32 mlID { get; set; }
        public Int32 statusID { get; set; }
        public string Notes { get; set; }
        public Int32? mastererID { get; set; }
    }
}
