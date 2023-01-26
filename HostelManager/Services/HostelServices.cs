using Elasticsearch.Net;
using HostelManager.Domain;
using HostelManager.Repositories;
using HostelManager.Services.Interface;
using ServiceStack;
using System.Linq;

namespace HostelManager.Services
{
    public class HostelServices : IHostelServices
    {
        private readonly IRepository<Hostel> _hostelRepository;

        public HostelServices(IRepository<Hostel> repository)
        {
            _hostelRepository = repository;
        }

        public string AddHostel(Hostel hostel)
        {

            _hostelRepository.Insert(hostel);

            return string.Empty;

            
        }

        public void DeleteHostel(int id)
        {

            var hostel = _hostelRepository.FilterBy(x => x.Id== id).FirstOrDefault();

            if (hostel == null)
            {
                throw new Exception();
            }

            _hostelRepository.Delete(hostel);
        }

       

        public IEnumerable<Hostel> GetAllHostels()
        {
            return _hostelRepository.GetAll();
        }

        void IHostelServices.UpdateHostel(Hostel hostel)
        {
             _hostelRepository.Update(hostel);
        }

        



    }
}

