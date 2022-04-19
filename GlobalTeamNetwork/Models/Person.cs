using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTeamNetwork.Models
{
    public class Person
    {
        [Key]
        public int personID { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int? locID { get; set; }
        public string? Notes { get; set; }
        public int? orgID { get; set; }
        public int personTypeID { get; set; }

    }
    public class PersonOname
    {
        [Key]
        public int personID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        //public string Location { get; set; }
        public int? locID { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Notes { get; set; }
        public int? orgID { get; set; }
        public string Organization { get; set; }
        public int personTypeID { get; set; }
        public string Role { get; set; }
    }
}
