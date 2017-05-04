using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Array Checksum

namespace Task_17
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
            Console.ReadKey();  //4241132
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
                    if(result>= 10000007)
                    {
                    result %= 10000007;
                    }
                }
            }
            
            return (int)result;
        }
        static void ReadFile()
        {
            numbers = new List<int>();
            int[] arrInt = File.ReadAllText(@"C:\Work\Codeabbey\1\Codeabbey\Task_17\file.txt", Encoding.UTF8).Split(' ').Select(Int32.Parse).ToArray();
            numbers.Add(Checksum(arrInt));
            //using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\1\Codeabbey\Task_17\file.txt", FileMode.Open, FileAccess.Read))
            //{
            //    using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
            //    {
            //        //while (!strRead.EndOfStream)
            //        //{
            //        //    int[] arrInt = strRead.ReadLine().Split(' ').Select(Int32.Parse).Where(val => val != 0).ToArray();
            //        //    numbers.Add(Checksum(arrInt));
                        

            //        //}
            //    }
            //}
        }
    }
}
