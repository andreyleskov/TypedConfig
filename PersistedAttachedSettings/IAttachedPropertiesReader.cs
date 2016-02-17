using System.Linq;

namespace PersistedAttachedProperties
{
    public interface IAttachedPropertiesReader
    {
        IQueryable<AttachedProperty> Properties { get; }
        IQueryable<AttachedPropertyValue<T>> AttachedPropertyValues<T>();
    }
}