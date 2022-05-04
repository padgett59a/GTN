namespace GlobalTeamNetwork.Models
{
    public class SessionDistribution
    {
        public int[] Sessions { get; set; }
        public string MediaTypes { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public char ArchiveType { get; set; }
        public int personID { get; set; }
        public string DistrDate { get; set; }
        public bool Masters { get; set; }
        public string Notes { get; set; }

    }
}
