using iikoTest.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace iikoTest.Services.Contexts
{
    public class AppContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public AppContext()
        {
            Database.EnsureCreated();
        }

        public AppContext(DbContextOptions<AppContext> options) : base(options) 
        { 

        }
    }
}
