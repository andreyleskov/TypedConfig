using System;

namespace PersistedAttachedProperties
{
    public interface IAttachedPropertiesUnitOfWork:IDisposable
    {
        void Commit();
        IAttachedPropertiesPersistance GetPersistance();
        IAttachedPropertiesReader GetReader();
    }
}