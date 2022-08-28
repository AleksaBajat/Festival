using System.Data.Entity;
using Context.Models;

namespace Context
{
    public class FestivalContext:DbContext
    {
        public FestivalContext()
        {
            
        }

        public DbSet<Account> Accounts { get; set; }

    }
}