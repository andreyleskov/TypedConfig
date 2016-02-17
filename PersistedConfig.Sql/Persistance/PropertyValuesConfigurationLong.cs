namespace PersistedConfig.Sql.Persistance
{
    public class PropertyValuesConfigurationLong : PropertyValuesConfigurationBase<long>
    {
        public string TableName { get { return "AttachedPropertyValuesBigInt"; } }
        /*public PropertyValuesConfigurationLong()
        {
            HasKey(v => new { v.PropertyId, v.EntityId });
            Property(t => t.PropertyId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(t => t.EntityId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(t => t.Value).HasMaxLength(Constants.Tables.Values.ValueMaxLength).IsVariableLength().IsOptional();
        }*/
    }
}