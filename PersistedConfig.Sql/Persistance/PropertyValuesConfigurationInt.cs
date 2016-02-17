namespace PersistedConfig.Sql.Persistance
{
    public class PropertyValuesConfigurationInt : PropertyValuesConfigurationBase<int>
    {
        public string TableName { get { return "AttachedPropertyValuesInt"; } }
        /*public PropertyValuesConfigurationInt()
        {
            HasKey(v => new {v.PropertyId, v.EntityId});
            Property(t => t.PropertyId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(t => t.EntityId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(t => t.Value).HasMaxLength(Constants.Tables.Values.ValueMaxLength).IsVariableLength().IsOptional();
        }*/
    }
}