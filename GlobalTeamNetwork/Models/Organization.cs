using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public class Organization
    {
        [Key]
        public int orgID{ get; set; }
        public string OrgName { get; set; }
        public int locID { get; set; }
        public string Notes { get; set; }
    }
    public class OrgLoc
    {
        [Key]
        public int orgID { get; set; }
        public string OrgName { get; set; }
        public int locID { get; set; }
        public string Notes { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

    }
}
