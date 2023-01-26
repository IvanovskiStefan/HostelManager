using HostelManager.Domain;
using HostelManager.Repositories;
using HostelManager.Services.Interface;
using Microsoft.Extensions.Hosting;

namespace HostelManager.Services
{
    public class RoomService : IRoomsService
    {

        private readonly IRepository<Room> _roomsRepository;

        public RoomService(IRepository<Room> repository)
        {
            _roomsRepository = repository;
        }
        public string AddRooms(Room room)
        {
           
            _roomsRepository.Insert(room);
            return string.Empty;
        }

        public void DeleteRooms(int id)
        {
            var room = _roomsRepository.FilterBy(x => x.Id == id).FirstOrDefault();

            if (room == null)
            {
                throw new Exception();
            }

            _roomsRepository.Delete(room);
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return _roomsRepository.GetAll();
        }

        public void UpdateRooms(Room room)
        {
            _roomsRepository.Update(room);
        }

        
    }
}
