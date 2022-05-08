using System;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = 1;
            var text = "Number: ";

            for (; a < 10; a++)
            {
                Console.WriteLine(text + a);
                Console.ReadKey();
            }
        }
    }
}
