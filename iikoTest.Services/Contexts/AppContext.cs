using iikoTest.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
