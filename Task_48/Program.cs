using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Collatz Sequence
/// <summary>
/// Входные данные содержат количество тестов в первой строке.
/// Вторая строка содержит сами тесты - т.е.исходные значения для которых нужно определить длину получаемых последовательностей.
/// Ответ должен содержать для каждого исходного значения полученное количество шагов(через пробел).
/// </summary>

namespace Task_48
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
        static int Collatz(int x)
        {
            if (x % 2 == 0)
            {
                x /= 2;
                return x;
            }
            else
            {
                x = 3 * x + 1;
                return x;
            }
        }
        static void ReadFile()
        {
            numbers = new List<int>();
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\1\Codeabbey\Task_48\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        int[] arrInt = strRead.ReadLine().Split(' ').Select(Int32.Parse).Where(val => val != 0).ToArray();
                        
                        foreach (var item in arrInt)
                        {
                            int count = 0;
                            int x = item;
                            do
                            {
                                count++;
                                x = Collatz(x);
                            } while (x!=1);
                            numbers.Add(count);
                        }
                        
                    }
                }
            }
        }
    }
}
