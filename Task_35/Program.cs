using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_35
{
    class Program
    {
        static public int S { get; set; }
        static public int R { get; set; }
        static public double P { get; set; }
        static public List<int> list = new List<int>();
        static void Main(string[] args)
        {
            ReadFile();
            Print();
        }
        static void Print()
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.ReadKey();
        }
        static void Calculator()
        {
            int years = 0;
            double result = S;
            while (result<R)
            {
                years++;
                result = Math.Round(result * P + result);
            }
            list.Add(years);

        }
        static void ReadFile()
        {

            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_35\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        int[] str = strRead.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
                        S = str[0];
                        R = str[1];
                        P = (double)str[2]/100;

                        Calculator();
                    }
                }
            }
        }
    }
}
