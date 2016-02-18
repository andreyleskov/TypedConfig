using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PersistedAttachedProperties;
using PersistedConfig.Sql.Persistance;
using TypedConfig.Deserialization;
using TypedConfig.TypedAdapter;

namespace PersistedConfig.Sql
{
    public class DbPersistedPropertyValueProvider<T, TKey> : IPropertyValueProvider 
        where T : class
        where TKey : struct, IComparable<TKey>
    {
        private readonly Func<IAttachedPropertyContext<TKey>> _contextCreator;
        private readonly T _defaultValues;
        private readonly TKey _ownerEntityId;
        private readonly Func<object, string> _serializer;
        private readonly TypedPropertyDeserializer<T> _typedPropertyDeserializer;

        private IDictionary<string, PersistedPropertyInfo> _knownProperties =
            new Dictionary<string, PersistedPropertyInfo>();

        private IDictionary<int, object> _loadedProperties = new Dictionary<int, object>();
        private IDictionary<string, string> _loadedSerializedProperties = new Dictionary<string, string>();

        public DbPersistedPropertyValueProvider(TKey ownerEntityId,
            Func<IAttachedPropertyContext<TKey>> contextCreator,
            Func<object, string> serializer,
            T defaultValues,
            ITypeDeserializer typeDeserializer)
        {
            _defaultValues = defaultValues;
            _serializer = serializer;
            _contextCreator = contextCreator;
            _ownerEntityId = ownerEntityId;
            _typedPropertyDeserializer = new TypedPropertyDeserializer<T>(
                prop => _loadedSerializedProperties[prop],
                typeDeserializer
                );
        }

        public IFlatProperty GetValue(string propertyName)
        {
            PersistedPropertyInfo property;
            if (!_knownProperties.TryGetValue(propertyName, out property))
            {
                InitPropertyDescriptions();
                property = _knownProperties[propertyName];
            }

            object propertyValue;
            if (!_loadedProperties.TryGetValue(property.Id, out propertyValue))
            {
                LoadValues();
            }

            return new FlatProperty(propertyName){Value =  _loadedProperties[property.Id]};
        }

        public void SetValue(string propertyName, object value)
        {
          //  ((IPropertyValueProvider) _typedPropertyDeserializer).SetValue(propertyName, value);
        }

        private void LoadValues()
        {
            using (var context = _contextCreator.Invoke())
            {
                InitSerializedValues(context);
                _loadedProperties = _loadedSerializedProperties.ToDictionary(p => _knownProperties[p.Key].Id
                                                                           , p => _typedPropertyDeserializer.GetValue(p.Key).Value);
            }
        }

        private void InitSerializedValues(IAttachedPropertyContext<TKey> context)
        {
            _loadedSerializedProperties = context.PropertyValues.Where(p => p.EntityId.CompareTo(_ownerEntityId) == 0)
                .ToDictionary(p => _knownProperties.Values.Single(v => v.Id == p.PropertyId).Info.Name,
                    p => p.Value);

            foreach (var prop in typeof (T).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(prop => !_loadedSerializedProperties.ContainsKey(prop.Name)))
            {
                var propInfo = _knownProperties[prop.Name];

                var attachedPropertyValue = new AttachedPropertyValue<TKey>
                {
                    EntityId = _ownerEntityId,
                    PropertyId = propInfo.Id,
                    Value = _serializer.Invoke(prop.GetValue(_defaultValues))
                };
                
                context.PropertyValues.Add(attachedPropertyValue);
                context.Save();

                _loadedSerializedProperties[prop.Name] = attachedPropertyValue.Value;
            }
        }

        private void InitPropertyDescriptions()
        {
            using (var context = _contextCreator.Invoke())
            {
                var type = typeof (T);
                var typeFullName = type.FullName;

                _knownProperties = context.Properties.Where(p => p.EntityType == typeFullName)
                    .ToDictionary(p => p.Name, p => new PersistedPropertyInfo
                    {
                        Id = p.Id,
                        Info = type.GetProperty(p.Name)
                    });

                foreach (var prop in type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Where(prop => !_knownProperties.ContainsKey(prop.Name)))
                {
                    var p = context.Properties.Add(new AttachedProperty
                    {
                        EntityType = typeFullName,
                        Name = prop.Name,
                        Type = prop.PropertyType.FullName
                    });
                    //supposing to have ownerEntityId filled by magic
                    context.Save();

                    _knownProperties[prop.Name] = new PersistedPropertyInfo
                    {
                        Id = p.Id,
                        Info = prop
                    };
                }
            }
        }

        private class PersistedPropertyInfo
        {
            public int Id { get; set; }
            public PropertyInfo Info { get; set; }
        }
    }
}