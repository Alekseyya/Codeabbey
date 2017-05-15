using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_81
{
    class Program
    {
        static public List<int> list;
        static public List<int> count;
        static void Main(string[] args)
        {
            ReadFile();
            Count();
            Print();
            Console.ReadKey();
        }
        static void Print()
        {
            foreach (var item in count)
            {
                Console.Write(item + " ");
            }
        }
        static void Count()
        {
            count = new List<int>();
            
            foreach (var item in list)
            {
                int iter = 0;
                char[] arr = GetIntBinaryString(item).ToCharArray();
                foreach (var itemArr in arr)
                {
                    if (itemArr == '1')
                        iter++;
                }
                count.Add(iter);
            }
        }
        static string GetIntBinaryString(int n)
        {
            char[] b = new char[32];
            int pos = 31;
            int i = 0;

            while (i < 32)
            {
                if ((n & (1 << i)) != 0)
                {
                    b[pos] = '1';
                }
                else
                {
                    b[pos] = '0';
                }
                pos--;
                i++;
            }
            return new string(b);
        }
        static void ReadFile()
        {
            list = new List<int>();
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_81\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        int[] str = strRead.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
                        foreach (var item in str)
                        {
                            list.Add(item);
                        }
                    }
                }
            }
        }
    }
}
