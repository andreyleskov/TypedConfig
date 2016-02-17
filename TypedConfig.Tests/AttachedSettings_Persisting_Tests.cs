using Domain;
using PerformanceSmokeTest;
using PersistedAttachedPropertiesConcrete.Persistance;
using PersistedConfig.Sql;
using Ploeh.AutoFixture;
using SpecsFor;

namespace TypedConfig.Tests
{
    public class AttachedSettings_Persisting_Tests : SpecsFor<AttachedConfigFactory<IExternalConfig_For_VK, int>>
    {
        protected int EntityId;
        protected IExternalConfig_For_VK Config;
        protected DefaultExampleConfig DefaultExampleConfig;

        protected override void Given()
        {
            using (var context = new PropertyContext())
            {
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE AttachedProperties");
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE AttachedPropertyValuesInt");
            }

            EntityId = (new Fixture()).Create<int>();
        }

        protected override void When()
        {
            DefaultExampleConfig = new DefaultExampleConfig();
            Config = SUT.Create(EntityId,
                DefaultExampleConfig,
                () => new ContextAdapter(new PropertyContext()),
                new KnownTypeDeserializer());
        }
    }
}