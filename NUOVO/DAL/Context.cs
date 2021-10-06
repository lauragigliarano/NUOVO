using NUOVO.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUOVO.DAL
{
    public class Context : DbContext
    {

        public Context() : base("Context")
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Commessa> Commessa { get; set; }
        public DbSet<Stackholder> Stackholder { get; set; }

        public DbSet<CommessaStackholder> CommessaStackholders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Commessa>()
            .HasRequired(p => p.Cliente)
            .WithMany(b => b.Commesse)
            .HasForeignKey(p => p.ClienteID);

        }
    }
}