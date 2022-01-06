using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public class MasteringStep
    {
        [Key]
        public int msID { get; set; }
        public string Step { get; set; }
        public decimal? DefaultPayDollars { get; set; }
        public string Notes { get; set; }

    }
}