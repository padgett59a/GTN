using System.ComponentModel.DataAnnotations;

namespace GlobalTeamNetwork.Models
{
    //This is the type returned from the SessionDistJoined VIEW
    public class SessionDistFull
    {
        [Key]
        public int sessionDistID { get; set; }
        public int sessionID { get; set; }
        public int langID { get; set; }
        public string langName { get; set; }
        public string SessionName { get; set; }
        public string CourseName { get; set; }
    }
}
