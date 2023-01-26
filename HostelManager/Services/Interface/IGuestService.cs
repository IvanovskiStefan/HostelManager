using HostelManager.Domain;

namespace HostelManager.Services.Interface
{
    public interface IGuestService
    {
        IEnumerable<Guest> GetAllGuests();
        //Hostel GetHostelByName(int id, int hostelId);

        string AddGuest(Guest guest);

        void DeleteGuest(int id);

        void UpdateGuest(Guest guest);

    }
}
