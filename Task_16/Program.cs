using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Average of an array

namespace Task_16
{
    class Program
    {
        static List<int> numbers;
        static void Main(string[] args)
        {
            ReadFile();
            StringBuilder str = new StringBuilder();
            foreach (var item in numbers)
            {
                str.Append(item + " ");
            }
            Console.ReadKey();
        }
        static void ReadFile()
        {
            numbers = new List<int>();
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\1\Codeabbey\Task_16\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        int[] arrInt = strRead.ReadLine().Split(' ').Select(Int32.Parse).Where(val=> val!=0).ToArray();
                        numbers.Add((int)Math.Round(arrInt.Average(), MidpointRounding.AwayFromZero));
                    }
                }
            }
        }
    }
}
