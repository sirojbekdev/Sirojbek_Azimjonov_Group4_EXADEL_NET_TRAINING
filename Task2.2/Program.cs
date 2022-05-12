using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Task2._2
{
    public class Program
    {
        static void Main(string[] args)
        {
            string file1 = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory+"Files/file1.txt");
            string file2 = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory+"Files/file2.txt");
            string file3 = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory+"Files/file3.txt");
            string[] files = new string[]
            {
                file1,file2,file3
            };
            //Console.WriteLine(text);
            //List<string> files = new List<string>()
            //{
            //    " Ak! NjodH22# pknGhb** gggruuee$67",
            //    "fkrfji rgjir rmgjK",
            //    "1111 1$%^&*"
            //};

            foreach (string file in files)
            {

                Console.WriteLine(file);
            }

            for (int file = 0; file < files.Length; file++)
            {
                string[] temp = Regex.Replace(files[file], @"[^a-z A-Z]", "").Split(' ').Reverse().ToArray();

                for (int word = 0; word < temp.Length; word++)
                {
                    for (int c = 0; c < temp[word].Length; c++)
                    {
                        if (char.IsUpper(temp[word][c]) && c != 0)
                        {
                            var index = temp[word].IndexOf(temp[word].FirstOrDefault(i => char.IsLower(i)));
                            temp[word] = temp[word].Remove(c, 1).Insert(index, temp[word][c].ToString());
                        }
                    }
                }
                files[file] = string.Join(" ", temp);
            }
            files = files.OrderBy(x=>x.Length).ToArray();
            Console.WriteLine("After Changes");
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }
    }
}
