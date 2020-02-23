using System.Reflection;

namespace Client.Comparer
{
    public class ObjectCompareChangeProperty
    {
        public PropertyInfo Name { get; set; }
        public object OldValue { get; set; }
        public object NewValue { get; set; }
    }
}