using System.Data.Entity;
using Context.Models;

namespace Context
{
    public class FestivalContext:DbContext
    {
        public FestivalContext()
        {
           Database.SetInitializer(new FestivalContextInitializer());
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<Artist> Artists { get; set; }

    }
}