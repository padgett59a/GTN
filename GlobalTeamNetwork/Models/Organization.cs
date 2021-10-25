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
        public string OrgLocation { get; set; }
    }
}
