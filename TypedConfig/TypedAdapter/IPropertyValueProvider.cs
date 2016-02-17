namespace TypedConfig.TypedAdapter
{
    public interface IPropertyValueProvider
    {
        object GetValue(string propertyName);
        void SetValue(string propertyName, object value);
    }
}