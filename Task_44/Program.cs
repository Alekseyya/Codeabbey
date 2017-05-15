using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_44
{
    class Program
    {
        public static List<int> numbers;

        static void Main(string[] args)
        {
            ReadFile();
            Print();
            Console.ReadKey();
        }

        static void Print()
        {
            foreach (var item in numbers)
            {
                Console.Write(item + " ");
            }
        }
        static void ReadFile()
        {
            numbers = new List<int>();
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_44\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        double[] aa = strRead.ReadLine().Split(' ').Select(Double.Parse).ToArray();
                        
                        numbers.Add(((int)aa[0] % 6 + 1) +((int)aa[1] % 6 + 1) );
                       


                    }
                }
            }
        }
    }
}
