namespace TypedConfig.TypedAdapter
{
    public interface IPropertyValueProvider
    {
        IFlatProperty GetValue(string propertyName);
   //     void SetValue(string propertyName, object value);
    }


    public interface IFlatEntityStorage<T>
    {
        IFlatProperty[] Flattern(T entity);
        T Build(IFlatProperty[] properties);
    }

    public interface IFlatProperty
    {
        string Name { get; }
        object Value { get; set; }
    }

    public class FlatProperty : IFlatProperty
    {
        public FlatProperty(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public object Value { get; set; }
    }
}