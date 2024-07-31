using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading.Classes
{
    public static class RandomIntArrayGenerator
    {
        public static long[] Generate(int size, int minValue, int maxValue)
        {
            long[] result = new long[size];

            Random rnd = new Random();

            for (int i = 0; i < size; i++)
            {
                result[i] = Convert.ToInt64(rnd.Next(minValue, maxValue + 1));
            }

            return result;
        }
    }
}
