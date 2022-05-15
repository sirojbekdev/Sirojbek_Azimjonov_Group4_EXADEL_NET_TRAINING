using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Task2._2
{
    public class Program
    {
        static void Main(string[] args)
        {
            string Path = AppDomain.CurrentDomain.BaseDirectory + "Files/";
            StringBuilder sb = new StringBuilder();
            string File1 = File.ReadAllText(Path+"file1.txt");
            string File2 = File.ReadAllText(Path+"file2.txt");
            string File3 = File.ReadAllText(Path+"file3.txt");
            string[] files = new string[]
            {
                File1,File2,File3
            };

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
            foreach (string file in files)
            {
               sb.AppendLine(file);
            }

            // Saving the output to file in bin/Debug/net5.0/Files
            using (StreamWriter sw = new StreamWriter(Path+"output.txt"))
            {
                // Deleting original files from bin/Debug/net5.0/Files
                // Only output.txt is there
                File.Delete(Path + "file1.txt");
                File.Delete(Path + "file2.txt");
                File.Delete(Path + "file3.txt");
                foreach (string file in files)
                {
                    sw.WriteLine(file);
                }
            }
        }
    }
}
