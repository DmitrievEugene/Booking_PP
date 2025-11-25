using Booking_PP.Config;
using Microsoft.EntityFrameworkCore;

namespace Booking_PP.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Room> Rooms => Set<Room>();

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder config)
        {
            var stringconnection = new ConfigurationBuilder()
                       .AddJsonFile("stringConnection.json")
                       .Build();

            config.UseNpgsql(stringconnection.GetConnectionString("Connection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
