using MultiThreading.Classes;
using System.Diagnostics;

int maxArraySize = 1000000000;

var generatedArray = RandomIntArrayGenerator.Generate(maxArraySize, 0, 100);
Console.WriteLine("Generation finished");

Stopwatch sw = new Stopwatch();

sw.Start();
Console.WriteLine(SumCalculator.SynchronousSumCalculation(generatedArray));
sw.Stop();
Console.WriteLine("Linear Spent time:" + sw.ElapsedMilliseconds.ToString());

sw.Reset();
sw.Start();
Console.WriteLine(SumCalculator.ParallelSumCalculator(generatedArray, 16));
sw.Stop();
Console.WriteLine("Parallel Spent time:" + sw.ElapsedMilliseconds.ToString());

sw.Reset();
sw.Start();
Console.WriteLine(SumCalculator.ParallelLinqSumCalculator(generatedArray));
sw.Stop();
Console.WriteLine("Parallel LINQ Spent time:" + sw.ElapsedMilliseconds.ToString());