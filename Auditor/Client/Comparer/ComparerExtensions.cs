using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Comparer
{
    public static class ComparerExtensions
    {
        public static ObjectCompareResponse DeepCompare(this object source, object comparer)
        {
            var response = new ObjectCompareResponse();

            if (ReferenceEquals(source, comparer)) return response;

            if ((source == null) || (comparer == null))
            {
                response.MarkAsNotEqual();
                return response;
            }

            //Compare two object's class, return false if they are difference
            //if (source.GetType() != comparer.GetType())
            //{
            //    response.MarkAsNotEqual();
            //    return response;
            //}


            //Get all properties of source
            //And compare each with comparer
            foreach (var property in source.GetType().GetProperties())
            {
                var sourceValue = property.GetValue(source);
                var comparerValue = property.GetValue(comparer);

                if (sourceValue == null)
                {
                    if (comparerValue == null)
                    {
                        response.AddToEqual(new ObjectCompareMatchProperty()
                        {
                            Name = property,
                            Value = null
                        });
                    }
                    else
                    {
                        response.AddToChange(new ObjectCompareChangeProperty()
                        {
                            Name = property,
                            OldValue = null,
                            NewValue = comparerValue
                        });
                    }

                    continue;
                }

                if (!sourceValue.Equals(comparerValue))
                {
                    response.AddToChange(new ObjectCompareChangeProperty()
                    {
                        Name = property,
                        OldValue = sourceValue,
                        NewValue = comparerValue
                    });
                }
                else
                {
                    response.AddToEqual(new ObjectCompareMatchProperty()
                    {
                        Name = property,
                        Value = sourceValue
                    });
                }
            }

            return response;
        }

    }
}
