// Task 3.1

using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

Dictionary <char, LinkedList<string?> > myDict = new();
Console.WriteLine("Enter Names: ");

string input = Console.ReadLine();
string raw = Regex.Replace(input, "[\" ]", "").Replace(","," ");

Queue<string> names = new Queue<string>(raw.Split());

for (char c = 'A'; c <= 'Z'; c++)
{
    myDict.Add(c, new LinkedList<string?>(names.Where(x => x.ToLower().StartsWith(c.ToString().ToLower()))));
}

foreach (var keyValuePair in myDict)
{
    StringBuilder sb = new StringBuilder();
    sb.AppendJoin(", ", keyValuePair.Value);
    Console.WriteLine($"key {keyValuePair.Key} : {sb.ToString()}");
}