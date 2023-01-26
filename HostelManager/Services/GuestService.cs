using HostelManager.Domain;
using HostelManager.Repositories;
using HostelManager.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace HostelManager.Services
{
    public class GuestService : IGuestService
    {

        private readonly IRepository<Guest> _guestRepository;

        public GuestService(IRepository<Guest> repository)
        {
            _guestRepository = repository;
        }


         string IGuestService.AddGuest(Guest guest)
        {
            

            _guestRepository.Insert(guest);

            return string.Empty;
        }

        public void DeleteGuest(int id)
        {
            var guest = _guestRepository.FilterBy(x => x.Id == id).FirstOrDefault();

            if (guest == null)
            {
                throw new Exception();
            }

            _guestRepository.Delete(guest);
        }


         IEnumerable<Guest> IGuestService.GetAllGuests()
        {
            return _guestRepository.GetAll();
        }

        void IGuestService.UpdateGuest(Guest guest)
        {
            _guestRepository.Update(guest);
        }
    }
}
