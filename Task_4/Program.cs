using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Входные данные - в первой строке указано количество пар сравниваемых чисел.
/// Следующие строки содержат сами эти пары - по одной на строку.
/// Ответ должен содержать наименьшие элементы из каждой пары, через пробел.

/// </summary>

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int countpar = 22;
            string pars = "-7234007 -2097534 -5305012 -4337899 2124873 6534740 -6073595 -51709 -5114673 -590863 -8449915 -7747767 -8826328 826185 7222686 2406580 -5134329 7386360 2432526 -3393976 -1635147 -9671721 -8458612 2720837 -1027804 -6391062 5567968 -5194961 7978139 6449790 -362729 -9255868 -5647744 4332258 -3593767 6477129 866998 332637 -3574580 5752325 9741773 -2024495 8004558 -9084554";
            var arrPar = pars.Split(' ').Select(Int32.Parse).ToArray();
            int min = 0;
            int k = 0;
            StringBuilder result = new StringBuilder();
            
            for (int i = 0; i < countpar; i++)
            {
                min = (arrPar[k] > arrPar[k + 1]) ? arrPar[k + 1] : arrPar[k];
                k += 2;
                result.Append(min + " ");
            }

            Console.ReadKey();
        }
    }
}
