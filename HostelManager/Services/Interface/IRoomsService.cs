using HostelManager.Domain;

namespace HostelManager.Services.Interface
{
    public interface IRoomsService
    {
        IEnumerable<Room> GetAllRooms();
        //Hostel GetHostelByName(int id, int hostelId);

        string AddRooms(Room room);

        void DeleteRooms(int id);

        void UpdateRooms(Room room);
    }
}
