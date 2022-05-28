using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6._2
{
    public class Methods
    {
        //string Output()
        //{

        //}
        public static async Task<double> CalculateAsync(string[] nums, char operation)
        {
            double[] arr = Array.ConvertAll(nums, double.Parse);
            var rresult = operation switch
            {
                '+' => await Task.Run(() => Sum(arr)),
                '-' => await Task.Run(() => Substract(arr)),
                '*' => await Task.Run(() => Multiply(arr)),
                '/' => await Task.Run(() => Divide(arr)),
                _ => throw new InvalidOperationException()
            };
            return rresult;
        }
        public static double Calculate(string[] nums, char operation)
        {
            double[] arr = Array.ConvertAll(nums, double.Parse);
            var rresult = operation switch
            {
                '+' => Sum(arr),
                '-' => Substract(arr),
                '*' => Multiply(arr),
                '/' => Divide(arr),
                _ => throw new InvalidOperationException()
            };
            return rresult;
        }


        private static double Multiply(double[] ints)
        {
            double result = ints[0];
            for (int i = 1; i < ints.Length; i++)
                result *= ints[i];
            return result;
        }

        private static double Divide(double[] ints)
        {
            double result = ints[0];
            for (int i = 1; i < ints.Length; i++)
            {
                if (ints[i] == 0)
                {
                    continue;
                }
                else
                {
                    result /= ints[i];
                }
            }
            return result;
        }

        private static double Substract(double[] ints)
        {
            double result = 0;
            for (int i = 1; i < ints.Length; i++)
                result -= ints[i];
            return result;
        }

        private static double Sum(double[] ints)
        {
            double result = ints[0];
            for (int i = 1; i < ints.Length; i++)
                result += ints[i];
            return result;
        }
    }
}
