using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Linear Function

namespace Task_10
{
    public class Linear
    {
        public int m { get; set; }
        public int g { get; set; }
    }
    class Program
    {
        public static Linear answer;
        public static List<Linear> listAnswer;

        static void Main(string[] args)
        {
            ReadFile();
            StringBuilder str = new StringBuilder();
            foreach (var item in listAnswer)
            {
                str.Append($"({item.m} {item.g}) ");
            }
            Console.ReadKey();
        }

        static int Find_Slope(int a, int b, int c, int d)
        {
            return (d - b) / (c - a);
        }
        static int Find_Intercept(int a, int b, int m)
        {
            return (b - m * a);
        }

        static void ReadFile()
        {
            listAnswer = new List<Linear>();
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_10\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        int[] arrInt = strRead.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
                        int m= Find_Slope(arrInt[0], arrInt[1], arrInt[2], arrInt[3]);
                        int g = Find_Intercept(arrInt[0], arrInt[1], m);
                        listAnswer.Add(new Linear { m = m, g = g });
                    }
                }
            }
        }
    }
}
