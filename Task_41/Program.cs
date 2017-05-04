using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Входные данные - первая строка содержит количество тестовых наборов чисел.
/// Остальные строки содержат сами наборы(тройки) - по одной в каждой строке.
/// Ответ должен содержать медианы этих троек, разделенные пробелами.
/// </summary>

namespace Task_41
{
    class Program
    {
        public static List<int> numbers;

        static void Main(string[] args)
        {
            ReadFile();
            StringBuilder answer = new StringBuilder();
            foreach (var item in numbers)
            {
                answer.Append(item + " ");
            }
            var t = 0;
        }
        static void ReadFile()
        {
            numbers = new List<int>();
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\1\Codeabbey\Task_41\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        string[] resultTmp = strRead.ReadLine().Split(' ');
                        int[] intArr = resultTmp.Select(Int32.Parse).ToArray();
                        int min = intArr[0];
                        int max = intArr[1];
                        int median = 0;
                        for (int i = 0; i < intArr.Length; i++)
                        {
                            if (intArr[i] <= min)
                            {
                                min = intArr[i];
                            }
                            if (intArr[i] >= max)
                            {
                                max = intArr[i];
                            }
                        }
                        for (int i = 0; i < intArr.Length; i++)
                        {
                            if(intArr[i]!=max & intArr[i] != min)
                            {
                                median = intArr[i];
                            }
                        }
                        
                        numbers.Add(median);
                    }
                }
            }
        }
    }
}
