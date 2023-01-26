using HostelManager.DataAccess;
using HostelManager.Domain;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Drawing;

namespace HosteManager.DataAccess
{
    public class HostelManagerDbContex : DbContext
    {
        public HostelManagerDbContex(DbContextOptions options) :base (options)
        {

        }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<Hostel> Hostels { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Hostel>()
               .HasMany(x => x.Rooms)
               .WithOne(x => x.Hostel)
               .HasForeignKey(x => x.Id);

            modelBuilder.Entity<Room>()
                .HasMany(x=>x.Guests);

                
            //add modelBuilder for guests!

            DataSeed.InsertDataInDb(modelBuilder);
        }

    }
}
