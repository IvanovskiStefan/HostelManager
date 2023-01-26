using HostelManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace HostelManager.DataAccess
{
    public class DataSeed
    {
        public static void InsertDataInDb(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hostel>()
                .HasData(
                   new Hostel
                {

                    HostelName = "NumberOne",
                    Address="Partizanski Odredi",
                    Id = 1
                },
                 new Hostel
                 {

                     HostelName = "NumberTwo",
                     Address = "Kliment Ohridski",
                     Id = 2
                 });

            modelBuilder.Entity<Room>()
                .HasData(
                   new Room
                   {
                       Id= 1,
                       Capacity = 3,
                       IsAvailable = true,
                       HostelId = 1,

                   },
                    new Room
                    {
                        Id = 2,
                        Capacity = 4,
                        IsAvailable = true,
                        HostelId = 2,

                    });

            modelBuilder.Entity<Guest>()
                .HasData(
                   new Guest
                   {

                       FirstName = "Stefan",
                       LastName = "Ivanovski",
                       Id = 1,


                   },
                   new Guest
                   {

                       FirstName = "Marija",
                       LastName = "Magdalena",
                       Id = 2,


                   });
                    

        }
    }
}
