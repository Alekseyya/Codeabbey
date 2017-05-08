using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_18
{
    class Program
    {
        private static List<double> numbers;

        static void Main(string[] args)
        {
            ReadFile();
            StringBuilder str = new StringBuilder();
            foreach (var item in numbers)
            {
                str.Append(item.ToString(CultureInfo.GetCultureInfo("en-GB")) + " ");
            }
            Console.ReadKey();
        }

        static int CreateResult(int tmp)
        {
            int nulResult = tmp;
            int remainder = 0;
            int count = 0;
            do
            {

                remainder = nulResult % 10;
                nulResult = nulResult / 10;
                count++;
                
            } while (nulResult != 0);
            return count;
        }

        static double Sqrt(int[] arrInt)
        {
            int value = arrInt[0];
            int runs = arrInt[1];
            double root = 1.00;
            
            

            for (int i = 1; i <= runs; i++)
            {
                double d = value/root;
                double razn = Math.Abs(root-d);
                root = (root + d) / 2;
            }
            
            return Math.Round(root,(12- CreateResult((int)root)));
        }
        static void ReadFile()
        {

            numbers = new List<double>();
            
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_18\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {

                        int[] arrInt = strRead.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
                        numbers.Add(Sqrt(arrInt));

                    }

                }
            }
        }
    }
}
