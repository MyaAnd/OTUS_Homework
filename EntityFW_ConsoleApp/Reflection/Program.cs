// See https://aka.ms/new-console-template for more information
using Reflection;
using System.Diagnostics;
using System.Text.Json;

Console.WriteLine("Hello, World!");


Program.Main();

static partial class Program
{

    static void Main()
    {
        F test = new F() { i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 };
        string serialized;
        F deserialized;

        Stopwatch serializationStopWatch = new Stopwatch();
        Stopwatch deserializationStopWatch = new Stopwatch();

        for (int i = 0; i < 100000; i++)
        {
            serializationStopWatch.Start();
            serialized = MySerializer<F>.Serialize(test);
            serializationStopWatch.Stop();

            deserializationStopWatch.Start();
            deserialized = MySerializer<F>.Deserialize(serialized);
            deserializationStopWatch.Stop();
        }

        Console.WriteLine($"Total serialization time of My serializer: {serializationStopWatch.Elapsed.TotalMilliseconds} milliseconds");
        Console.WriteLine($"Total deserialization time of My serializer: {deserializationStopWatch.Elapsed.TotalMilliseconds} milliseconds");

        serializationStopWatch.Reset();
        deserializationStopWatch.Reset();

        for (int i = 0; i < 100000; i++)
        {
            serializationStopWatch.Start();
            serialized = JsonSerializer.Serialize(test);
            serializationStopWatch.Stop();

            deserializationStopWatch.Start();
            deserialized = JsonSerializer.Deserialize<F>(serialized)!;
            deserializationStopWatch.Stop();
        }

        Console.WriteLine($"Total serialization time of JsonSerializer: {serializationStopWatch.Elapsed.TotalMilliseconds} milliseconds");
        Console.WriteLine($"Total deserialization time of JsonSerializer: {deserializationStopWatch.Elapsed.TotalMilliseconds} milliseconds");
        serializationStopWatch.Reset();
        deserializationStopWatch.Reset();

        string filePathIni = "FSerialized.ini";
        string filePathCsv = "FSerialized.csv";

        MySerializer<F>.SerializeToFile(filePathCsv, test);

        for (int i = 0; i < 100000; i++)
        {
            deserializationStopWatch.Start();
            deserialized = MySerializer<F>.DeserializeFromFile(filePathCsv);
            deserializationStopWatch.Stop();
        }
        Console.WriteLine($"Total deserialization time of My serializer from file: {deserializationStopWatch.Elapsed.TotalMilliseconds} milliseconds");
    }
}
