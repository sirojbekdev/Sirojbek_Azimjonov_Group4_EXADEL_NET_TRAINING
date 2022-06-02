using System.Diagnostics;
using Task6._2;

Thread thread1 = new(()=> Threaded("Files/file1.txt"));
Thread thread2 = new(()=> Threaded("Files/file2.txt"));

Console.WriteLine("1.Asynchronous\n2.Multi - threaded");
int key = Convert.ToInt32(Console.ReadLine());
if (key == 1) {
	Stopwatch stopwatch = Stopwatch.StartNew();
	await Asynchronoues();
	stopwatch.Stop();
	Console.WriteLine("Time:" + stopwatch.ElapsedMilliseconds);
}
else if (key == 2) {
	Stopwatch stopwatch = Stopwatch.StartNew();
	Console.WriteLine("MultiThreded method");
	thread1.Start();
	thread1.Join();
	thread2.Start();
	thread2.Join();
	stopwatch.Stop();
	Console.WriteLine("Time:" + stopwatch.ElapsedMilliseconds);
}
else {
	Console.WriteLine("wrong");
}

void Threaded(string filePath)
{
	Methods md = new(filePath);
	md.Read();
	double result = Methods.Calculate(md.Arr, md.Operation);
	md.PrintResult(result);
}

async Task Asynchronoues()
{
	Console.WriteLine("Asynchronous method");
	await Task.WhenAll();
	Methods md1 = new("Files/file1.txt");
	Methods md2 = new("Files/file2.txt");
	await md1.ReadAsync();
	await md2.ReadAsync();
	double result1 = await Methods.CalculateAsync(md1.Arr, md1.Operation);
	double result2 = await Methods.CalculateAsync(md2.Arr, md2.Operation);
	md1.PrintResult(result1);
	md2.PrintResult(result2);
}