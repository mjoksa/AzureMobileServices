// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExistingContext.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   The existing context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Tables;

namespace CustomersSampleService.Models
{
    /// <summary>
    /// The existing context.
    /// </summary>
    public class CustomersContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersContext"/> class.
        /// </summary>
        public CustomersContext()
            : base("Name=MS_TableConnectionString")
        {
        }

        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        /// <value>
        /// The customers.
        /// </value>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        /// <value>
        /// The orders.
        /// </value>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            string schema = ServiceSettingsDictionary.GetSchemaName();
            if (!string.IsNullOrEmpty(schema))
            {
                modelBuilder.HasDefaultSchema(schema);
            }

            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
       
            modelBuilder.Entity<Customer>()
                   .HasMany(e => e.Orders)
                   .WithRequired(e => e.Customer)
                   .HasForeignKey(e => e.CustomerId)
                   .WillCascadeOnDelete(false);
        }
   }
}