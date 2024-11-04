using Microsoft.EntityFrameworkCore;
using Trial_Core_App.Models;

namespace Trial_Core_App.Data
{
    //Inherit from the DbContext class in the Entity Framework Core
    public class Trial_Core_AppContext:DbContext
    {
        //Constructor for the context
        public Trial_Core_AppContext(DbContextOptions<Trial_Core_AppContext> options) : base(options) { }

        //A DBSet called items
        public DbSet<Item> Items { get; set; }
    }
}
