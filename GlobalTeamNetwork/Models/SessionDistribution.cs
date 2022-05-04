﻿namespace GlobalTeamNetwork.Models
{
    public class SessionDistribution
    {
        public int sessionDistID { get; set; }
        public int sessionID { get; set; }
        public string mediaTypeIDs { get; set; }
        public int locID { get; set; }
        public char ArchiveFormat { get; set; }
        public int personID { get; set; }
        public bool Masters { get; set; }
        public string Notes { get; set; }

    }
    public class SessionDistLoc
    {
        public int[] Sessions { get; set; }
        public string DistrDate { get; set; }
        public string mediaTypeIDs { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public char ArchiveType { get; set; }
        public int personID { get; set; }
        public bool Masters { get; set; }
        public string Notes { get; set; }

    }
}
