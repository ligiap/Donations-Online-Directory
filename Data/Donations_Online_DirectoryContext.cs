using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Donations_Online_Directory.Models;

namespace Donations_Online_Directory.Data
{
    public class Donations_Online_DirectoryContext : DbContext
    {
        public Donations_Online_DirectoryContext (DbContextOptions<Donations_Online_DirectoryContext> options)
            : base(options)
        {
        }

        public DbSet<Donations_Online_Directory.Models.Product> Product { get; set; }

        public DbSet<Donations_Online_Directory.Models.Category> Category { get; set; }
    }
}
