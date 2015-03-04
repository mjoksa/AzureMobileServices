using System.Data.Entity.Migrations;

namespace EFRelationshipSample.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Models.MobileServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.MobileServiceContext context)
        {
           // add data to the database where!
        }
    }
}
