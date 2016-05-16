using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using PersistedAttachedProperties.AttachedProperties;

namespace PersistedAttachedProperties.Persistance
{
    public class AttachedPropertyValueLong : AttachedPropertyValue<long>
    {
    }
    public class AttachedPropertyValueInt : AttachedPropertyValue<int>
    {
    }


    public class PropertyValueConfigurationInt : EntityTypeConfiguration<AttachedPropertyValueInt>
    {
        public string TableName => nameof(AttachedPropertyValueInt);

        public PropertyValueConfigurationInt()
        {
            ToTable(TableName);
            HasKey(v => new { v.PropertyId, v.EntityId });
            Property(t => t.PropertyId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(t => t.EntityId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(t => t.Value).HasMaxLength(Constants.Tables.Values.ValueMaxLength).IsVariableLength().IsOptional();
        }
    }

    public class PropertyValueConfigurationLong : EntityTypeConfiguration<AttachedPropertyValueLong>

    {
        public string TableName => nameof(AttachedPropertyValueLong);

        public PropertyValueConfigurationLong()
        {
            ToTable(TableName);
            HasKey(v => new { v.PropertyId, v.EntityId });
            Property(t => t.PropertyId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(t => t.EntityId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(t => t.Value).HasMaxLength(Constants.Tables.Values.ValueMaxLength).IsVariableLength().IsOptional();
        }
    }
}