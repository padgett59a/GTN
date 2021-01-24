﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public class MediaType
    {
        [Key]
        public int MediaTypeId  { get; set; }
        public string MediaTypeName { get; set; }
    }
}
