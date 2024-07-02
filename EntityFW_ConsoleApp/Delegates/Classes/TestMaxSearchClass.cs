using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Classes
{
    public class TestMaxSearchClass
    {
        public string _stringValue;

        public TestMaxSearchClass(float searchValue)
        {
            _stringValue = searchValue.ToString();
        }

        public static float ConvertionMehtod(TestMaxSearchClass classItem)
        {
            return float.Parse(classItem._stringValue);
        }
    }
}
