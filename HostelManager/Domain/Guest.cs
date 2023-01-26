namespace HostelManager.Domain
{
    public class Guest : BaseEntity
    {
        public string ?FirstName { get; set; }
        public string ?LastName { get; set; }
        public Room? Room { get; set; }
        public int? RoomId { get; set; }
    }
}
