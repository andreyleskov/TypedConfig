using System.Data.Entity;
using PersistedAttachedProperties.AttachedProperties;

namespace PersistedAttachedProperties.Persistance
{
    public class PropertyContext : DbContext
    {
        public DbSet<DomainEntity> DomainEntities { get; set; }
        public DbSet<AttachedPropertyValueLong> AttachedPropertyValueLong { get; set; }
        public DbSet<AttachedPropertyValueInt> AttachedPropertyValueInt { get; set; }
        public DbSet<AttachedProperty> AttachedProperties { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PropertyConfiguration());
            modelBuilder.Configurations.Add(new PropertyValueConfigurationInt());
            modelBuilder.Configurations.Add(new PropertyValueConfigurationLong());
        }

        public PropertyContext(string connectionString):base(connectionString)
        { 
            Database.SetInitializer(new CreateDatabaseIfNotExists<PropertyContext>());
        }

        public PropertyContext() : this("Server=(localdb)\\v11.0;Integrated Security=true;Initial Catalog=PropertyContext")
        {
            
        }
    }
}