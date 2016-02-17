using System;
using ImpromptuInterface;
using TypedConfig.TypedAdapter;

namespace PersistedAttachedProperties
{
    public interface IAttachedConfigStorage<TConfigType, TKey>
                                         where TConfigType : class
                                         where TKey : struct, IComparable<TKey>
    {
        TConfigType Get(TKey ownerEntityKey);
        void Save(TConfigType config);
    }

     //public TConfigType Create(TKey entityId,
     //                          TConfigType defaults,
     //                          Func<IAttachedPropertyContext<TKey>> propertyInfos,
     //                          ITypeDeserializer typeDeserializer)
     //{
     //    var valueProvider = new DbPersistedPropertyValueProvider<TConfigType, TKey>(entityId, propertyInfos,
     //        //consider provide proper serializer implementation
     //        o => o.ToString(),
     //        defaults,
     //        typeDeserializer);
     //    return new FlatValuesToTypedClassAdapter(valueProvider).ActLike<TConfigType>();
     //}


    public interface IPropertyValuePersist
    {
        void SetValue(string propertyName, string value);
    }

    public class AttachedConfigStorage<TConfigType, TKey> : IAttachedConfigStorage<TConfigType, TKey>
        where TConfigType : class
        where TKey : struct, IComparable<TKey>
    {
        private readonly Func<IAttachedPropertiesUnitOfWork> _uowFactory;
        private readonly Func<TKey, IPropertyValueProvider> _propValueProvider;

        public AttachedConfigStorage(Func<TKey,IPropertyValueProvider> propValueProvider)
        {
            _propValueProvider = propValueProvider;
            //_uowFactory = uowFactory;
        }


        public TConfigType Get(TKey ownerEntityKey)
        {
            return new FlatValuesToTypedClassAdapter(_propValueProvider.Invoke(ownerEntityKey)).ActLike<TConfigType>();
        }

        public void Save(TConfigType config)
        {
            throw new NotImplementedException();
        }
    }
}
