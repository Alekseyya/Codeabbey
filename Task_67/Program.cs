using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Task_67
{
    class Program
    {
        private static List<int> numbers;

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
        static int Fibonacci(BigInteger number)
        {
            //F(n)
            BigInteger x = new BigInteger(1);
            //F(n-1)
            BigInteger y = new BigInteger(0);
            
            int count = 1;
            while (x!=number)
            {
                x += y;
                y = x - y;
                count++;
            }
            return count;
        }
        static void ReadFile()
        {
            numbers = new List<int>();
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_67\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        BigInteger value = BigInteger.Parse(strRead.ReadLine());
                       
                        numbers.Add(Fibonacci(value));
                    }
                }
            }
        }
    }
}
