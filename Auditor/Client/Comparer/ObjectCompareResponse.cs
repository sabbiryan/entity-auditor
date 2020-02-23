using System.Collections.Generic;

namespace Client.Comparer
{
    public class ObjectCompareResponse
    {
        private bool IsEquality { get; set; } = true;

        public bool IsEqual => IsEquality && ChangeProperties.Count == 0;

        public List<ObjectCompareMatchProperty> EqualProperties { get; set; } = new List<ObjectCompareMatchProperty>();
        public List<ObjectCompareChangeProperty> ChangeProperties { get; set; } = new List<ObjectCompareChangeProperty>();


        public void MarkAsEqual()
        {
            this.IsEquality = true;
        }


        public void MarkAsNotEqual()
        {
            this.IsEquality = false;
        }

        public void AddToEqual(ObjectCompareMatchProperty property)
        {
            this.EqualProperties.Add(property);
        }

        public void AddToChange(ObjectCompareChangeProperty property)
        {
            this.ChangeProperties.Add(property);
        }
    }
}