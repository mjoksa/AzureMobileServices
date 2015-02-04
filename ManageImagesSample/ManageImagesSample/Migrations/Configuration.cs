using System;
using System.Data.Entity.Migrations;
using ManageImagesSample.DataObjects;

namespace ManageImagesSample.Migrations
{
    /// <summary>
    /// Define the Configuration. This class cannot be inherited.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<Models.MobileServiceContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// Seeds the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        protected override void Seed(Models.MobileServiceContext context)
        {
            context.Cars.AddOrUpdate(item => item.Id, new Car()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Test",
                Url="http://www.freelargeimages.com/wp-content/uploads/2014/11/Car_clipart.png"
            });
        }
    }
}
