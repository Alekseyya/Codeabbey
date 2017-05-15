using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//через формулу герона

namespace Task_9
{
    class Program
    {
        static public int A { get; set; }
        static public int B { get; set; }
        static public int C { get; set; }

        
        static public List<double> list = new List<double>();
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

        static void Test()
        {
            if (A + B > C)
                list.Add(1);
            else list.Add(0);
            
        }
        static void ReadFile()
        {

            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_9\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        int[] str = strRead.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
                        A = str.Min();
                        C = str.Max();
                        for (int i = 0; i < str.Length; i++)
                        {
                            if (str[i] != A & str[i] != C)
                                B = str[i];
                        }
                        Test();
                    }
                }
            }
        }
    }
}
