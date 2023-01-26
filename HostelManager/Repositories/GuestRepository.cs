using HostelManager.Domain;
using HosteManager.DataAccess;
using System.Linq;

namespace HostelManager.Repositories
{
    public class GuestRepository : IRepository<Guest>
    {
        private readonly HostelManagerDbContex _context;

        public GuestRepository(HostelManagerDbContex context)
        {
            _context = context;
        }

        public IEnumerable<Guest> FilterBy(Func<Guest, bool> filter)
        {
            return _context.Guests.Where(filter);
        }

        int IRepository<Guest>.Delete(Guest entity)
        {
            _context.Guests.Remove(entity);
            _context.SaveChanges();
            return entity.Id;
        }



        IEnumerable<Guest> IRepository<Guest>.GetAll()
        {
            return _context.Guests;
        }

        Guest IRepository<Guest>.GetById(int id)
        {
            return _context.Guests.FirstOrDefault(x => x.Id == id);
        }

        int IRepository<Guest>.Insert(Guest entity)
        {
            _context.Guests.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        int IRepository<Guest>.Update(Guest entity)
        {
            _context.Guests.Update(entity);
            _context.SaveChanges();
            return entity.Id;
        }
    }
}
