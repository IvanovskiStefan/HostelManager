using Dapper;
using Elasticsearch.Net;
using HostelManager.Domain;
using HostelManager.Services;
using HosteManager.DataAccess;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Options;
using Nest;

namespace HostelManager.Repositories
{
    public class HostelRepository : IRepository<Hostel>
    {
        private readonly HostelManagerDbContex _context;

        public HostelRepository(HostelManagerDbContex context)
        {
            _context = context;
        }

        public IEnumerable<Hostel> FilterBy(Func<Hostel, bool> filter)
        {
            return _context.Hostels.Where(filter);
        }

        int IRepository<Hostel>.Delete(Hostel entity)
        {
            _context.Hostels.Remove(entity);
            _context.SaveChanges();
            return entity.Id;
        }

      

        IEnumerable<Hostel> IRepository<Hostel>.GetAll()
        {
            return _context.Hostels;
        }

        Hostel IRepository<Hostel>.GetById(int id)
        {
            return _context.Hostels.FirstOrDefault(x => x.Id == id);
        }

        int IRepository<Hostel>.Insert(Hostel entity)
        {
            _context.Hostels.Add(entity);
            
            _context.SaveChanges();
            return entity.Id; 
        }

        int IRepository<Hostel>.Update(Hostel entity)
        {
            _context.Hostels.Update(entity);
            _context.SaveChanges();
            return entity.Id;
        }
    }
}
