// Task 3.1

using System.Collections.Generic;
using System.Text;

Dictionary <char, LinkedList<string?> > myDict = new();
Console.WriteLine("Enter Names: ");
string[] input = Console.ReadLine().Split( ", " );
Queue<string> names = new Queue<string>(input);

for (char c = 'A'; c <= 'Z'; c++)
{
    myDict.Add(c, new LinkedList<string?>(names.Where(x=>x.StartsWith(c)))); 
}

foreach(var keyValuePair in myDict)
{
    StringBuilder sb = new StringBuilder();
    sb.AppendJoin(", ", keyValuePair.Value);
    Console.WriteLine($"key {keyValuePair.Key} : {sb.ToString()}");
}