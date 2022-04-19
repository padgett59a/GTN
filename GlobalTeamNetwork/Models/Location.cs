using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public class Location
    {
        [Key]
        public int locID { get; set; }
        public string LocName { get; set; }
        public bool ArchiveLocation { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
