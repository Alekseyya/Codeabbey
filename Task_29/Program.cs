using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Sort with Indexes
/// <summary>
/// http://www.codeabbey.com/index/task_view/sort-with-indexes--ru
/// </summary>
namespace Task_29
{
    class Program
    {
        public static List<int> numbers;
        public static int[] arrInt;

        static void Main(string[] args)
        {
            ReadFile();
            StringBuilder str = new StringBuilder();
            foreach (var item in numbers)
            {
                str.Append(item + " ");
            }
            Console.ReadKey();   ///13 1 11 9 2 10 4 16 7 12 14 8 5 18 19 3 17 15 6
        }
        static void SortWithIndex(int[] arrInt)
        {
            int[] arr = new int[arrInt.Length];
            for (int i = 0; i < arrInt.Length; i++)
            {
                arr[i] = arrInt[i];
            }
            arr=BubleSort(arr);
            for (int i = 0; i < arr.Length; i++)
            {
               numbers.Add(Array.IndexOf(arrInt, arr[i])+1);
            }

        }
        static int[] BubleSort(int[] arr)
        {
            bool sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (int i = 0; i < arr.Length-1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        sorted = false;
                        int tmp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = tmp;
                    }
                }
            }
            return arr;
        }
        static void ReadFile()
        {
            numbers = new List<int>();
            arrInt = File.ReadAllText(@"C:\Work\Codeabbey\Task_29\file.txt", Encoding.UTF8).Split(' ').Select(Int32.Parse).ToArray();
            SortWithIndex(arrInt);
            
        }
    }
}
