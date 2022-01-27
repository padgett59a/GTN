using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalTeamNetwork.Models
{
    public class TranslationLogUpdate
    {

        //This is the type returned from the SP_Trx_Sem stored procedure
        [Key] 
        public Int32 tlID { get; set; }
        public Int32 statusID { get; set; }
        public string Notes { get; set; }
        public Int32? translatorID { get; set; }
    }
}
