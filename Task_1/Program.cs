using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Входные данные содержат в первой строке N - общее количество пар, которые нужно посчитать.
//Последующие N строк содержат по одной паре целых чисел каждая.
//Ответ должен содержать результаты, разделенные пробелами.

    /// <summary>
    /// входные данные:
    /// 3
    /// 100 8
    /// 15 245
    /// 1945 54
    /// ответ:
    /// 108 260 1999
    /// </summary>

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int countpar = 14;
            string pars = "127266 815694 433620 561804 411976 110549 256714 975748 909527 120933 469743 311558 794158 110491 898603 653727 874898 40941 404919 128587 301849 745378 888928 612190 78267 888781 281401 540789";
            int[] arrPar = pars.Split(' ').Select(Int32.Parse).ToArray();
            int sum = 0;
            int k = 0;
            StringBuilder result = new StringBuilder();
            List<int> summList = new List<int>();
            for (int i = 0; i < countpar; i++)
            {
                sum = arrPar[k] + arrPar[k + 1];
                k+=2;
                result.Append(sum + " ");
            }
            
            Console.ReadKey();
        }
    }
}
