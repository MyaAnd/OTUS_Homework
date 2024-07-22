using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading.Classes
{
    public static class SumCalculator
    {
        private static uint CalculateSumInRange(uint[] array, int start, int end)
        {
            uint sum = 0;

            for (int i = start; i <= end; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static uint SynchronousSumCalculation(uint[] array)
        {
            return CalculateSumInRange(array, 0, array.Length - 1);
        }

        public static uint ParallelSumCalculator(uint[] array, int threadsUsed)
        {
            int step = Convert.ToInt32(Math.Round((double)(array.Length - 1) / threadsUsed));


            List<Task<uint>> sumTasks = new List<Task<uint>>();

            for (int i = 0; i < threadsUsed; i++)
            {
                int startPos = i * step;
                int endPos = startPos + step - 1;

                if (i == threadsUsed - 1)
                {
                    endPos = array.Length - 1;
                }

                sumTasks.Add(Task.Run(() => CalculateSumInRange(array, startPos, endPos)));
            }

            Task.WhenAll(sumTasks);


            uint sum = 0;
            foreach (Task<uint> task in sumTasks)
            {
                sum += task.Result;
            }

            return sum;
        }
    }
}