using System.Diagnostics;
using Task6._2;

Thread thread1 = new(new ThreadStart(FirstThread));
Thread thread2 = new(new ThreadStart(SecondThread));

Console.WriteLine("1.Asynchronous\n2.Multi - threaded");
int key = Convert.ToInt32(Console.ReadLine());
if (key == 1)
	await Asynchronoues();
else if (key == 2)
	MultiThreded();
else
	Console.WriteLine("wrong");


void MultiThreded()
{
	Console.WriteLine("MultiThreded method");
	Stopwatch stopwatch = new();
	stopwatch.Start();
	thread1.Start();
	thread2.Start();
	stopwatch.Stop();
	Console.WriteLine("Time:" + stopwatch.ElapsedMilliseconds);
}

void FirstThread()
{
	string[] file1 = File.ReadAllLines("Files/file1.txt");
	var num1 = file1[0].Split(',');
	char op1 = file1[1].Single();
	double result1 = Methods.Calculate(num1, op1);
    var newNums = num1.Select(x => double.Parse(x) < 0 ? x = "(" + x + ")" : x).ToArray();
	string news1 = String.Join(op1, newNums);
	Console.WriteLine("file1: " + news1 + " = " + result1);
}
void SecondThread()
{
	string[] file2 = File.ReadAllLines("Files/file2.txt");
	var num2 = file2[0].Split(',');
	char op2 = file2[1].Single();
	double result2 = Methods.Calculate(num2, op2);
	var newNums = num2.Select(x => double.Parse(x) < 0 ? x = "(" + x + ")" : x).ToArray();
	string news2 = String.Join(op2, newNums);
	Console.WriteLine("file2: " + news2 + " = " + result2);
}

async Task Asynchronoues()
{
	Console.WriteLine("Asynchronous method");
	Stopwatch timer = new();
	timer.Start();

	await Task.WhenAll();
	string[] file1 = await File.ReadAllLinesAsync("Files/file1.txt");
	var num1 = file1[0].Split(',');
	char op1 = file1[1].Single(); 
	string[] file2 = await File.ReadAllLinesAsync("Files/file2.txt");
	var num2 = file2[0].Split(',');
	char op2 = file2[1].Single();
	double result1 = await Methods.CalculateAsync(num1, op1);
	double result2 = await Methods.CalculateAsync(num2, op2);
	var newNums1 = num1.Select(x => double.Parse(x) < 0 ? x = "(" + x + ")" : x).ToArray();
	var newNums2 = num2.Select(x => double.Parse(x) < 0 ? x = "(" + x + ")" : x).ToArray();
	string news1 = String.Join(op1, num1);
	string news2 = String.Join(op2, num2);
	Console.WriteLine("file1: "+ news1+ " = " + result1);
	Console.WriteLine("file2: "+ news2+ " = " + result2);
	timer.Stop();
    Console.WriteLine("Time:" + timer.ElapsedMilliseconds);

}