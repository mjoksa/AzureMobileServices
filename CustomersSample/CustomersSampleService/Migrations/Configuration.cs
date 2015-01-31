using System;
using System.Data.Entity.Migrations;
using CustomersSampleService.Models;

namespace CustomersSampleService.Migrations
{
    /// <summary>
    /// Class Configuration. This class cannot be inherited.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<CustomersContext>
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
        protected override void Seed(CustomersContext context)
        {
            context.Customers.AddOrUpdate(item=>item.Id, new Customer()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Test"
            });
        }
    }
}
