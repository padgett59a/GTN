using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public class Status
    {
        [Key]
        public int statusID { get; set; }
        public string status { get; set; }
    }
}
