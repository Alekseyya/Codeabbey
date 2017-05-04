using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Входные данные имеют такой формат:
/// первая строка содержит число N - количество тестов которые нужно обработать;
/// следующие N строк содержат по три целых числа A B C, составляющих один тест;
/// для каждого теста нужно умножить A на B и добавить C(т.е.A* B + C) - после чего сосчитать сумму цифр результата.
/// Ответ должен содержать N результатов, разделенных пробелами.
/// </summary>
/// 
namespace Task_11
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
        static int SplitString(string str)
        {
            string[] arrStr = str.Split(' ');
            int result = Convert.ToInt32(arrStr[0]) * Convert.ToInt32(arrStr[1]) + Convert.ToInt32(arrStr[2]);
            return result;
        }

        static int SumResult(int resultTmp)
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
            } while (nulResult!=0);

            foreach (var item in listNumbers)
            {
                summ += item;
            }
            return summ;
        }
        static void ReadFile()
        {
            numbers = new List<int>();
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\1\Codeabbey\Task_11\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        int resultTmp = SplitString(strRead.ReadLine());
                        int summ = SumResult(resultTmp);
                        numbers.Add(summ);
                    }
                }
            }
        }
    }
}
