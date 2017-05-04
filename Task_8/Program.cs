using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Арифметическая  прогрессия
namespace Task_8
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

        static int ArithmeticProgression(int a, int step, int countFirstMember)
        {
            int answer = a;
            for (int i = 1; i < countFirstMember; i++)
            {
                answer += a + i * step;
            }
            return answer;
        }
        static void ReadFile()
        {
            numbers = new List<int>();
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\1\Codeabbey\Task_8\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        int[] arrInt = strRead.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
                        
                        numbers.Add(ArithmeticProgression(arrInt[0], arrInt[1], arrInt[2]));
                    }
                }
            }
        }
    }
}
