using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_25
{
    class Program
    {
        static public int A { get; set; }
        static public int C { get; set; }
        static public int M { get; set; }
        static public int X0 { get; set; }
        static public int N { get; set; }

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
        static void LinearGenerator()
        {
            int result = X0;
            for (int i = 1; i <=N; i++)
            {
                int Xnext = (A * result + C) % M;
                result = Xnext;
            }
            list.Add(result);
        }
        static void ReadFile()
        {

            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_25\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        int[] str = strRead.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
                        A = str[0];
                        C = str[1];
                        M = str[2];
                        X0 = str[3];
                        N = str[4];
                        LinearGenerator();
                    }
                }
            }
        }
    }
}
