using DotrA_Lab.ORM.Context;
using System.Data.Entity.Migrations;

namespace DotrA_Lab.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DotrADbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DotrADbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
