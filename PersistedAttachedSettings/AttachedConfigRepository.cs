using System;

namespace PersistedAttachedProperties
{
    public class AttachedConfigRepository<TConfigType, TKey>
        where TConfigType : class
        where TKey : struct, IComparable<TKey>
    {
        //public AttachedSettingsProxy(ITypeDeserializer deserializer, ITypeSerializer serializer)
        //{

        //}
    }
}
