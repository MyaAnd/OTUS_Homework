using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Classes
{
    public static class AdvancedMath
    {
        public static T GetMax<T>(IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
        {
            if ((collection is null) || (collection.Count() == 0)) 
            {
                throw new Exception("Empty collection!"); 
            }

            var listCollection = collection.ToList();

            var convertedCollection = listCollection.Select(el => convertToNumber(el)).ToList();

            return listCollection[convertedCollection.IndexOf(convertedCollection.Max())];
        }

        public static float NextFloat()
        {
            Random random = new Random();

            double mantissa = (random.NextDouble() * 2.0) - 1.0;
            // choose -149 instead of -126 to also generate subnormal floats (*)
            double exponent = Math.Pow(2.0, random.Next(-126, 128));
            return (float)(mantissa * exponent);
        }
    }
}
