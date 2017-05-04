using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_23
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
        static int Checksum(int[] arrInt)
        {
            long result = 0;
            checked
            {
                for (int i = 0; i < arrInt.Length; i++)
                {
                    result += arrInt[i];
                    result *= 113;
                    if (result >= 10000007)
                    {
                        result %= 10000007;
                    }
                }
            }

            return (int)result;
        }

        static void BubleSort(int[] arrInt)
        {
            int swapcount = 0;
                for (int i = 0; i < arrInt.Length - 1; i++)
                {

                    if (arrInt[i] > arrInt[i + 1])
                    {

                        
                        int tmp = arrInt[i];
                        arrInt[i] = arrInt[i + 1];
                        arrInt[i + 1] = tmp;
                        swapcount++;
                    }

                }
          
            numbers.Add(swapcount);
        }
        static void ReadFile()
        {
            numbers = new List<int>();
            int[] arrInt = File.ReadAllText(@"C:\Work\Codeabbey\Codeabbey\Task_23\file.txt", Encoding.UTF8).Split(' ').Select(Int32.Parse).ToArray();
            
            BubleSort(arrInt);
            numbers.Add(Checksum(arrInt));
        }
    }
}
