using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading.Classes
{
    public static class SumCalculator
    {
        private static int CalculateSumInRange(int[] array, int start, int end)
        {
            int sum = 0;

            for (int i = start; i <= end; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static int SynchronousSumCalculation(int[] array)
        {
            return CalculateSumInRange(array, 0, array.Length - 1);
        }

        public static int ParallelSumCalculator(int[] array, int threadsUsed)
        {
            int step = Convert.ToInt32(Math.Round((double)(array.Length - 1) / threadsUsed));
            int startPos = 0;
            int endPos = 0;

            List<Task<int>> sumTasks = new List<Task<int>>();

            for(int i = 0; i < threadsUsed; i++)
            {
                startPos = i * step;
                endPos = startPos + step - 1;

                if (i == threadsUsed - 1)
                {
                    endPos = array.Length - 1;
                }

                sumTasks.Add(Task.Run(() => CalculateSumInRange(array, startPos, endPos)));
            }
            
            return Task.WhenAll(sumTasks).Result.Sum();
        }
    }
}