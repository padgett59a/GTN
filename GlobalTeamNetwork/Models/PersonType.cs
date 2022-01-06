using System.ComponentModel.DataAnnotations;

namespace GlobalTeamNetwork.Models
{
    public class PersonType
    {
        [Key]
        public int personTypeID { get; set; }
        public string PersonTypeName { get; set; }
    }
}
