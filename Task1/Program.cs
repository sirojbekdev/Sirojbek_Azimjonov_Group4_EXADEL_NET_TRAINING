using System;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var text = "Number: ";

            for (var a = 1; a < 10; a++)
            {
                Console.WriteLine(text + a);
                Console.ReadKey();
            }
        }
    }
}
