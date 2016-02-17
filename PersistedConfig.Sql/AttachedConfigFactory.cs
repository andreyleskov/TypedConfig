using System;
using ImpromptuInterface;
using PersistedConfig.Sql.Persistance;
using TypedConfig.Deserialization;
using TypedConfig.TypedAdapter;

namespace PersistedConfig.Sql
{
    public class AttachedConfigFactory<TConfigType, TKey> where TConfigType : class
        where TKey : struct, IComparable<TKey>
    {
        public TConfigType Create(TKey entityId,
                                  TConfigType defaults,
                                  Func<IAttachedPropertyContext<TKey>> propertyInfos,
                                  ITypeDeserializer typeDeserializer)
        {
            var valueProvider = new DbPersistedPropertyValueProvider<TConfigType, TKey>(entityId, propertyInfos,
                //consider provide proper serializer implementation
                o => o.ToString(),
                defaults,
                typeDeserializer);
            return new FlatValuesToTypedClassAdapter(valueProvider).ActLike<TConfigType>();
        }
    }
}