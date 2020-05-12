﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public class TranslationStep
    {
        [Key]
        public int tsID { get; set; }
        public string Step { get; set; }

        [Column(TypeName = "decimal(19,2)")]
        public decimal? DefaultPayDollars { get; set; }
        public string Notes { get; set; }

    }
}
