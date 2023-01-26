using HostelManager.Domain;
using HosteManager.DataAccess;
using Nest;
using System.Linq;

namespace HostelManager.Repositories
{
    public class RoomsRepository : IRepository<Room>
    {
        private readonly HostelManagerDbContex _context;

        public RoomsRepository(HostelManagerDbContex context)
        {
            _context = context;
        }

        public int Delete(Room entity)
        {
            _context.Rooms.Remove(entity);
            _context.SaveChanges();
            return entity.Id; ;
        }

        public IEnumerable<Room> FilterBy(Func<Room, bool> filter)
        {
            return _context.Rooms.Where(filter);
        }

        public IEnumerable<Room> GetAll()
        {
            return _context.Rooms;

        }

        public Room GetById(int id)
        {
            return _context.Rooms.FirstOrDefault(x => x.Id == id); ;
        }

        int IRepository<Room>.Insert(Room entity) 
        {
            _context.Rooms.Add(entity);
            _context.SaveChanges();
            return entity.Id; ;
        }

        public int Update(Room entity)
        {
            _context.Rooms.Update(entity);
            _context.SaveChanges();
            return entity.Id; ;
        }
    }
}
