using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_14
{
    class Program
    {
        static public int[] arrInt; //1863
        static public List<int> numbers;


        static void Main(string[] args)
        {
            int a = 7315;
            int b = 1461;
            int sum = a * b;
            int suma = (a * b) % 6907;
            ReadFile();
        }
        static int Operator(string logic, int n, int number, int mod)
        {
            checked
            {
                switch (logic)
                {
                    case "+": return (n % mod + number % mod) % mod;
                    case "*": return (n % mod * number % mod) % mod;
                    case "%": return n % number;
                    default: throw new Exception("invalid logic");
                }
            }
            
        }

//       
        static int modCalc(string log, int n, int number)
        {
            while (log != "%")
            {
                if (log == "+")
                {
                    return n += number;
                }
                if (log == "*")
                {
                    return n *= number;
                }
            }
           return n %= number;
        }

        static void ReadFile() //4246
        {
            int n = 4;
            int summ = 0;
            numbers = new List<int>();
            
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_14\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                       
                       string[] arrInt = strRead.ReadLine().Split(' ').ToArray();
                       n= Operator(arrInt[0], n, Convert.ToInt32(arrInt[1]), 5343);
                       
                    }
                    int t = n;
                }
            }
        }
    }
}
