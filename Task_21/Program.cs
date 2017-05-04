using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Входные данные содержат M и N в первой строке.
/// Вторая строка(довольно длинная) содержит M чисел, через пробел.
/// Ответ должен содержать ровно N чисел, разделенных пробелами. Первое должно означать количество единиц в исходном массиве, второе - количество двоек и так далее.
/// </summary>

namespace Task_21
{
    class Program
    {
        public static int[] numbers;
        public static int[] arr;

        static void Main(string[] args)
        {
            arr = new int[7];
            int k = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = k;
                k++;
            }

            ReadFile();
            StringBuilder resultat = new StringBuilder();
            foreach (var item in numbers)
            {
                resultat.Append(item + " ");
            }
        }
        static void ReadFile()
        {
            numbers = new int[arr.Length];
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\1\Codeabbey\Task_21\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    
                     while (!strRead.EndOfStream)
                    {
                        int[] arrInt= strRead.ReadLine().Split(' ').Select(int.Parse).ToArray();
                        for (int i = 0; i < arrInt.Length; i++)
                        {
                            for (int j = 0; j < arr.Length; j++)
                            {
                                
                                if (arrInt[i] == arr[j])
                                {
                                    numbers[j] += 1;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
