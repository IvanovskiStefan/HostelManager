namespace HostelManager.Domain
{
    public class Room :BaseEntity 
    {
        public int?  Capacity { get; set; }
        public List<Guest>? Guests { get; set; }
        public bool? IsAvailable { get; set; }
        public Hostel? Hostel { get; set; }
        public int? HostelId { get; set; }

    }
}
