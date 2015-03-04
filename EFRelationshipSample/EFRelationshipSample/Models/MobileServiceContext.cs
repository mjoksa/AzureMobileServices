using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.WindowsAzure.Mobile.Service.Tables;

namespace EFRelationshipSample.Models
{

    public class MobileServiceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to alter your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
        //
        // To enable Entity Framework migrations in the cloud, please ensure that the 
        // service name, set by the 'MS_MobileServiceName' AppSettings in the local 
        // Web.config, is the same as the service name when hosted in Azure.

        private const string connectionStringName = "Name=MS_TableConnectionString";

        public MobileServiceContext()
            : base(connectionStringName)
        {
            Configuration.LazyLoadingEnabled = false;
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Speaker> Speakers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Using Entity Framework Fluent API to define relationships
            
            //mapping related with User that has Friends and UnFriends which are Users
            modelBuilder.Entity<User>().HasMany(x => x.Friends).WithMany()
                    .Map(x => x.ToTable("Friends"));

            modelBuilder.Entity<User>().HasMany(x => x.UnFriends).WithMany()
                .Map(x => x.ToTable("UnFriends"));


            //mapping Country and Cities -> 1:N
            modelBuilder.Entity<City>()
                      .HasRequired<Country>(s => s.Country)
                      .WithMany(s => s.Cities)
                      .HasForeignKey(s => s.CountryId);

            // mapping Events and Speakers -> N:M
            modelBuilder.Entity<Event>()
                .HasMany<Speaker>(s => s.Speakers)
                .WithMany(c => c.Events)
                .Map(cs =>
                {
                    cs.MapLeftKey("EventId");
                    cs.MapRightKey("SpeakerId");
                    cs.ToTable("Talks");
                });

            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
        }   
    }
}
