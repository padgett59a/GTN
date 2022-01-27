using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalTeamNetwork.Models
{
    public class TranslationLog
    {

        //This is the type returned from the SP_Trx_Sem stored procedure
        [Key] 
        public Int32 tlID { get; set; }
        public Int32 tsID { get; set; }
        public Int32 sessionID { get; set; }
        public Int32 statusID { get; set; }
        public DateTime? DatePaid { get; set; }
        public string Notes { get; set; }
        public Int32? translatorID { get; set; }
        public Decimal? StepPaymentAmount { get; set; }

    }
}
