using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Подсчет контрольных сумм(CRC), MD5
/// </summary>
/// 
///Входные данные задают в первой строке общее количество тестов.
///Сами тестовые значения заданы во второй строке.Для каждого из них нужно сосчитать "взвешенную сумму цифр".
///Ответ - как обычно, выведите результаты для каждого теста через пробел.

namespace Task_13
{
    class Program
    {
        public static List<int> numbers;

        static void Main(string[] args)
        {
            ReadFile();
            StringBuilder str = new StringBuilder();
            foreach (var item in numbers)
            {
                str.Append(item + " ");
            }
        }
        static int WSD(int resultTmp)
        {
            List<int> listNumbers = new List<int>();
            int nulResult = resultTmp;
            int remainder = 0;
            int summ = 0;
            do
            {

                remainder = nulResult % 10;
                nulResult = nulResult / 10;

                listNumbers.Add(remainder);
            } while (nulResult != 0);
            
            for (int i = listNumbers.Count-1, j=1; i >=0; i--, j++)
            {
                summ += listNumbers[i] * j;
            }
            
            return summ;
        }
        static void ReadFile()
        {
            numbers = new List<int>();
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\1\Codeabbey\Task_13\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {

                    while (!strRead.EndOfStream)
                    {
                        int[] arrInt = strRead.ReadLine().Split(' ').Select(int.Parse).ToArray();
                        for (int i = 0; i < arrInt.Length; i++)
                        {
                            numbers.Add(WSD(arrInt[i]));
                        }
                    }
                }
            }
        }
    }
}
