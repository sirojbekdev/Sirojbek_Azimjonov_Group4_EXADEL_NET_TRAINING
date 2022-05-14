using System;
using System.Linq;

namespace Task2._1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter value for a between 0 and 5");
            int a = Convert.ToInt32(Console.ReadLine());
            bool aFlag = Enumerable.Range(0, 6).Contains(a);
            while (!aFlag)
            {
                if (!Enumerable.Range(0, 6).Contains(a))
                {
                    Console.WriteLine("Please, enter proper value for a between 0 and 5");
                    a = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    aFlag = true;
                }
            }

            double aFactorial = 1;
            for (int x = 1; x <= a; x++)
            {
                aFactorial *= x;
            }

            Console.WriteLine("Enter value for b between 0 and 100");
            int b = Convert.ToInt32(Console.ReadLine());
            bool bFlag = Enumerable.Range(0, 101).Contains(b);
            while (!bFlag)
            {
                if (!Enumerable.Range(0, 101).Contains(b))
                {
                    Console.WriteLine("Please, enter proper value for b between 0 and 100");
                    b = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    bFlag = true;
                }
            }

            double bLogorithm = Math.Log(b);
            var aValue = Math.Round(aFactorial*0.05,2);
            var bValue = Math.Round(bLogorithm,2);

            if (aValue > bValue)
            {
                Console.WriteLine($"Number 'a' = {aValue} and more than number 'b' = {bValue}");
            }
            else if(aValue < bValue)
            {
                Console.WriteLine($"Number 'a' = {aValue} and less than number 'b' = {bValue}");
            }
            else
            {
                Console.WriteLine($"Number 'a' = {aValue} and equal to number 'b' = {bValue}");
            }
        }
    }
}
