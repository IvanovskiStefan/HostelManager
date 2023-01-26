namespace HostelManager.Domain
{
    public class Hostel : BaseEntity
    {

        public string ?HostelName { get; set; }
        public List<Room>? Rooms { get; set; }
        public string ?Address { get; set; }

    }
}
