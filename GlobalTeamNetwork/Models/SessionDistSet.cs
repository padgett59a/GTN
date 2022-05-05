using System.ComponentModel.DataAnnotations;

namespace GlobalTeamNetwork.Models
{
    public class SessionDistSet
    {
        [Key]
        public int sessionDistID { get; set; }
        public string DistMonthYear { get; set; }
        public string mediaTypeIDs { get; set; }
        public int locID { get; set; }
        public char ArchiveFormat { get; set; }
        public int? personID { get; set; }
        public bool Masters { get; set; }
        public string Notes { get; set; }

    }
}
