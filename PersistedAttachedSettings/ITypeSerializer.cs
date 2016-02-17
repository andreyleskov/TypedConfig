using System;

namespace PersistedAttachedProperties
{
    public interface ITypeSerializer
    {
        string Serialize(object value);
        bool CanSerialize(Type type);
    }
}