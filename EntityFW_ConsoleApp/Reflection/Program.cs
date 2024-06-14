// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Text.Json;

Console.WriteLine("Hello, World!");


Program.Main();

static partial class Program
{

    public class F
    {
        public int i1 { get; set; }
        public int i2 { get; set; }
        public int i3 { get; set; }
        public int i4 { get; set; }
        public int i5 { get; set; }
        static void Get() => new F() { i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 };
        public static string Serialize(F f)
        {
            return $"{f.i1},{f.i2},{f.i3},{f.i4},{f.i5}";
        }

        public static F Deserialize(string f)
        {
            int separatorIndex = f.IndexOf(",");
            int i1 = Int32.Parse(f.Substring(0, separatorIndex));
            f = f.Substring(separatorIndex + 1, f.Length - separatorIndex - 1);

            separatorIndex = f.IndexOf(",");
            int i2 = Int32.Parse(f.Substring(0, separatorIndex));
            f = f.Substring(separatorIndex + 1, f.Length - separatorIndex - 1);

            separatorIndex = f.IndexOf(",");
            int i3 = Int32.Parse(f.Substring(0, separatorIndex));
            f = f.Substring(separatorIndex + 1, f.Length - separatorIndex - 1);

            separatorIndex = f.IndexOf(",");
            int i4 = Int32.Parse(f.Substring(0, separatorIndex));
            f = f.Substring(separatorIndex + 1, f.Length - separatorIndex - 1);

            int i5 = Int32.Parse(f);

            return new F() { i1 = i1, i2 = i2, i3 = i3, i4 = i4, i5 = i5 };
        }

        public static F DeserializeFromFile(string filePath)
        {
            return Deserialize(File.ReadAllText(filePath));
        }
    }


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
            serialized = F.Serialize(test);
            serializationStopWatch.Stop();

            deserializationStopWatch.Start();
            deserialized = F.Deserialize(serialized);
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

        for (int i = 0; i < 100000; i++)
        {
            deserializationStopWatch.Start();
            deserialized = F.DeserializeFromFile("FSerialized.txt");
            deserializationStopWatch.Stop();
        }
        Console.WriteLine($"Total deserialization time of My serializer from file: {deserializationStopWatch.Elapsed.TotalMilliseconds} milliseconds");
    }
}
