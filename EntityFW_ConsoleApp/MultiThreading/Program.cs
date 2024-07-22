using MultiThreading.Classes;
using System.Diagnostics;

int maxArraySize = 5;

var generatedArray = RandomIntArrayGenerator.Generate(maxArraySize, 0, 10);

Stopwatch sw = new Stopwatch();

sw.Start();
Console.WriteLine(SumCalculator.SynchronousSumCalculation(generatedArray));
sw.Stop();
Console.WriteLine("Spent time:" + sw.ElapsedMilliseconds.ToString());

sw.Reset();
sw.Start();
Console.WriteLine(SumCalculator.ParallelSumCalculator(generatedArray, 5));
sw.Stop();
Console.WriteLine("Spent time:" + sw.ElapsedMilliseconds.ToString());

Console.ReadLine();