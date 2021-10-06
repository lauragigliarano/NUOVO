namespace NUOVO.Migrations.MigrationsB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ConfigurationB : DbMigrationsConfiguration<NUOVO.Models.ApplicationDbContext>
    {
        public ConfigurationB()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "NUOVO.Models.ApplicationDbContext";
        }

        protected override void Seed(NUOVO.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
