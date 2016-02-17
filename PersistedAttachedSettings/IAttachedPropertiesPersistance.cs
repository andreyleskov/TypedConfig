namespace PersistedAttachedProperties
{
    public interface IAttachedPropertiesPersistance
    {
        void AddOrUpdate(AttachedProperty property);
        void AddOrUpdate<T>(AttachedPropertyValue<T> propertyValue);
    }
}