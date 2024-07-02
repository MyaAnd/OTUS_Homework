// See https://aka.ms/new-console-template for more information
using Delegates.Classes;


Console.WriteLine("Hello, World!");

List<TestMaxSearchClass> searchCollection = new List<TestMaxSearchClass>();
for(int i = 0; i < 10; i++)
{
    searchCollection.Add(new TestMaxSearchClass(AdvancedMath.NextFloat()));
    Console.WriteLine(searchCollection[i]._stringValue);
}

Console.WriteLine();
Console.WriteLine(@"MaxValue = {0}", AdvancedMath.GetMax<TestMaxSearchClass>(searchCollection, TestMaxSearchClass.ConvertionMehtod)._stringValue);


FileSearcher fs = new FileSearcher();

List<string> filesNames = new List<string>() { "a.txt", "b.ini" };
string fileDir = @"C:\SearchFiles";

fs.SearchForFiles(fileDir, filesNames);



