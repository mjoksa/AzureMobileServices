using AzureMobileService.DataObjects;

namespace AzureMobileService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class Configuration. This class cannot be inherited.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<AzureMobileService.Models.MobileServiceContext>
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
            context.TodoItems.AddOrUpdate(
               p => p.Id,
               new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Clean the car." },
               new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Read a book" }
             );

            base.Seed(context);
        }
    }
}
