using Parallelism.Classes;
using System.Diagnostics;

//used https://onlinefiletools.com/generate-random-text-file to generate 10 mB files of text
string filePath1 = @"C:\SearchFiles\1.txt";
string filePath2 = @"C:\SearchFiles\2.txt";
string filePath3 = @"C:\SearchFiles\3.txt";

Stopwatch stopwatch = new Stopwatch();

stopwatch.Start();

Task t1 = new Task(() => Console.WriteLine(@"file: {0} contains {1} spaces", filePath1, FileWorker.ReadFileAndCalculateSpaces(filePath1).Result));
Task t2 = new Task(() => Console.WriteLine(@"file: {0} contains {1} spaces", filePath2, FileWorker.ReadFileAndCalculateSpaces(filePath2).Result));
Task t3 = new Task(() => Console.WriteLine(@"file: {0} contains {1} spaces", filePath3, FileWorker.ReadFileAndCalculateSpaces(filePath3).Result));

t1.Start();
//await t1;
t2.Start();
//await t2;
t3.Start();
//await t3;

await Task.WhenAll(t1, t2, t3);
//it takes more than 300 milliseconds for consecutive case and close to 200 milliseconds for parallel case

stopwatch.Stop();
Console.WriteLine(@"Time it took: {0} milliseconds", stopwatch.ElapsedMilliseconds);

string directoryPath = @"C:\SearchFiles";

stopwatch.Reset();
stopwatch.Start();
await FileWorker.ReadFilesFromDirectoryAndCalculateSpaces(directoryPath);
stopwatch.Stop();

Console.WriteLine(@"Time it took: {0} milliseconds", stopwatch.ElapsedMilliseconds);