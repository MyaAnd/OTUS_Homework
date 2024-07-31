using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading.Classes
{
    public static class SumCalculator
    {
        private static long CalculateSumInRange(long[] array, int start, int end)
        {
            long sum = 0;

            for (int i = start; i <= end; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static long SynchronousSumCalculation(long[] array)
        {
            return CalculateSumInRange(array, 0, array.Length - 1);
        }

        public static long ParallelSumCalculator(long[] array, int threadsUsed)
        {
            int step = Convert.ToInt32(Math.Round((double)(array.Length - 1) / threadsUsed));


            List<Task<long>> sumTasks = new List<Task<long>>();

            for (int i = 0; i < threadsUsed; i++)
            {
                int startPos = i * step;
                int endPos = startPos + step - 1;

                if (i == threadsUsed - 1)
                {
                    endPos = array.Length - 1;
                }

                sumTasks.Add(Task.Run(() =>
                {
                    //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                    return CalculateSumInRange(array, startPos, endPos);
                }));
            
            }

            Task.WhenAll(sumTasks);


            long sum = 0;
            foreach (Task<long> task in sumTasks)
            {
                sum += task.Result;
            }

            return sum;
        }

        public static long ParallelLinqSumCalculator(long[] array)
        {
            var pq = array.AsParallel();
            return pq.Sum();
        }
    }
}