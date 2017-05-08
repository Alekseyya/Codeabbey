using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Greatest Common Divisor
///НОД двух чисел A и B называют такое третье число C что оба первых делятся на него без остатка, при этом C должно быть наибольшим из возможных.Например gcd(20, 35) = 5 а gcd(13, 28) = 1. Алгоритм Евклида заключается в том что из большего числа вычитают меньшее, повторяя эту операцию пока числа не сравняются - это и будет НОД.Для ускорения можно не вычитать, а брать остаток от деления.

///Если кажется что это очень абстрактные математические "фокусы", то стоит обратить внимание что делимость чисел вообще и НОД в частности положены в основу современной криптографии (в чем вы убедитесь из дальнейших задач).

namespace Task_26
{
    class Program
    {
        public static List<int> numbers;
        static public StringBuilder str;
        static public int[] arrInt;
        static public int Min { get; set; }
        static public int Max { get; set; }
        static public int Nod { get; set; }
        static public int Nok { get; set; }

        static void Main(string[] args)
        {
            ReadFile();
            
        }
        static void MaxMin(int[] arr)
        {
            int min = arr[0];
            int max = arr[1];
           
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] <= min)
                {
                    min = arr[i];
                    Min = min;

                }
                   
                if (arr[i] >= max)
                {
                    max = arr[i];
                    Max = max;
                }
                    
            }
            
        }

        
        static int NOD(int a, int b)
        {
            int t = 0;
            while (b != 0)
            {
                t = b;
                b = a % b;
                a = t;
            }
            return Nod=a;
        }

        static void NOK()
        {
            Nok = arrInt[0] * arrInt[1] / NOD(arrInt[0], arrInt[1]);
        }
        static void ReadFile() 
        {
            
            numbers = new List<int>();
             str =new StringBuilder();
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_26\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {

                        arrInt = strRead.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
                        MaxMin(arrInt);
                        NOD(Max, Min);
                        NOK();
                        
                        str.Append($"({Nod} {Nok}) ");
                       
                    }
                    
                }
            }
        }
    }
}
