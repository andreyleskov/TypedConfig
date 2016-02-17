using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using PersistedAttachedProperties;

namespace PersistedConfig.Sql.Persistance
{
    public abstract class PropertyValuesConfigurationBase<T> : EntityTypeConfiguration<AttachedPropertyValue<T>>
        where T : struct
    {
        protected PropertyValuesConfigurationBase()
        {
            HasKey(v => new { v.PropertyId, v.EntityId });
            Property(t => t.PropertyId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(t => t.EntityId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(t => t.Value).HasMaxLength(Constants.Tables.Values.ValueMaxLength).IsVariableLength().IsOptional();
        }
    }
}