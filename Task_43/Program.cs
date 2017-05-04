using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Входные данные содержат в первой строке число значений, которые нужно преобразовать.
/// Остальные строки содержат по одному вещественному случайному числу каждая(в виде 0.142857 и т.п.)
/// Ответ должен содержать числа от 1 до 6 для каждого из входных тестов, через пробел.
/// </summary>

namespace Task_43
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
        static void ReadFile()
        {
            numbers = new List<int>();
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\1\Codeabbey\Task_43\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        double  aa = Convert.ToDouble(strRead.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
                        int result = (int)Math.Floor(aa * 6 + 1);
                        numbers.Add(result);
                    }
                }
            }
        }
    }
}
