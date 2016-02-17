using System;
using System.Data.Entity;
using PersistedAttachedProperties;

namespace PersistedConfig.Sql.Persistance
{
    public interface IAttachedPropertyContext<T> : IDisposable
    {
        IDbSet<AttachedProperty> Properties { get; }
        IDbSet<AttachedPropertyValue<T>> PropertyValues { get; }
        void Save();
    }
}