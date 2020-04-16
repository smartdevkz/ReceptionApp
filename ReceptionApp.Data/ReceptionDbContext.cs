using Microsoft.EntityFrameworkCore;
using ReceptionApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptionApp.Data
{
    public class ReceptionDbContext : DbContext
    {
        public ReceptionDbContext(DbContextOptions<ReceptionDbContext> options) : base(options)
        {
        }

        public DbSet<Visitor> Visitors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visitor>().ToTable("Visitor");
        }
    }
}
