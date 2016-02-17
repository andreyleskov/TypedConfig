namespace PersistedAttachedProperties
{
    public class AttachedPropertyValue<T>
    {
        public T EntityId { get; set; }
        public int PropertyId { get; set; }
        public string Value { get; set; }
    }
}