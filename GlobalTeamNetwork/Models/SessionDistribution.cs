using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalTeamNetwork.Models
{
    public class SessionDistribution
    {
        //composite key sessionDistID, sessionID 
        public int sessionDistID { get; set; }
        public int sessionID { get; set; }
    }

    //object for data coming from the UI
    public class SessionDistLoc
    {
        public int sessionDistID { get; set; }
        public int[] Sessions { get; set; }
        public string DistrDate { get; set; }
        public string mediaTypeIDs { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public char ArchiveType { get; set; }
        public int? personID { get; set; }
        public bool Masters { get; set; }
        public string Notes { get; set; }
    }
}
