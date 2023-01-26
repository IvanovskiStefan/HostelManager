using HostelManager.Domain;

namespace HostelManager.Services.Interface
{
    public interface IHostelServices
    {
        IEnumerable<Hostel> GetAllHostels();
        //Hostel GetHostelByName(int id, int hostelId);

        string AddHostel(Hostel hostel);

        void DeleteHostel(int id);

        void UpdateHostel(Hostel hostel);
    }
}
