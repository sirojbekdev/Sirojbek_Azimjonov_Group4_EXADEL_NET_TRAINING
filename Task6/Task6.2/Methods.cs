namespace Task6._2
{
    public class Methods
    {
        public string _filePath;
        private string[] _lines;
        public double[] Arr;
        public char Operation;

        public Methods(string filePath)
        {
            _filePath = filePath;
        }

        public async Task ReadAsync()
        {
            _lines = await File.ReadAllLinesAsync(_filePath);
            Arr = Array.ConvertAll(_lines[0].Split(','),double.Parse);
            Operation = _lines[1].Single();
        }      
        public void Read()
        {
            _lines = File.ReadAllLines(_filePath);
            Arr = Array.ConvertAll(_lines[0].Split(','),double.Parse);
            Operation = _lines[1].Single();
        }

        public void PrintResult(double result)
        {
            var newNums = _lines[0].Split(',').Select(x => double.Parse(x) < 0 ? x = "(" + x + ")" : x).ToArray();
            string news1 = String.Join(Operation, newNums);
            Console.WriteLine(value:(_filePath) + " " + news1 + " = " + result);
        }

        public static async Task<double> CalculateAsync(double[] nums, char operation)
        {
            var rresult = operation switch
            {
                '+' => await Task.Run(() => Sum(nums)),
                '-' => await Task.Run(() => Substract(nums)),
                '*' => await Task.Run(() => Multiply(nums)),
                '/' => await Task.Run(() => Divide(nums)),
                _ => throw new InvalidOperationException()
            };
            return rresult;
        }
        public static double Calculate(double[] nums, char operation)
        {
            var rresult = operation switch
            {
                '+' => Sum(nums),
                '-' => Substract(nums),
                '*' => Multiply(nums),
                '/' => Divide(nums),
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
                    continue;
                else
                    result /= ints[i];
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
