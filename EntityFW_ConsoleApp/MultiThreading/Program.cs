using MultiThreading.Classes;
using System.Diagnostics;

int maxArraySize = 1000000000;

var generatedArray = RandomIntArrayGenerator.Generate(maxArraySize, 0, 100);

Stopwatch sw = new Stopwatch();

sw.Start();
Console.WriteLine(SumCalculator.SynchronousSumCalculation(generatedArray));
sw.Stop();
Console.WriteLine("Spent time:" + sw.ElapsedMilliseconds.ToString());

sw.Reset();
sw.Start();
Console.WriteLine(SumCalculator.ParallelSumCalculator(generatedArray, 1000));
sw.Stop();
Console.WriteLine("Spent time:" + sw.ElapsedMilliseconds.ToString());