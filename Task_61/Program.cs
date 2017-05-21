using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_61
{
    class Program
    {
        static public List<int> list;
        static public List<int> answer = new List<int>();
        static public int[] arr = Erotosfen(20000000);
        static void Main(string[] args)
        {
            ReadFile();
            Count();
            Print();


        }
        static void Print()
        {
            foreach (var item in answer)
            {
                Console.Write(item + " ");
            }
            Console.ReadKey();
        }

        static void Count()
        {
            //int[] arr = Erotosfen(200000);
            foreach (var item in list)
            {
                int count = 0;
                int index = 0;
                for (int i = 0; i < arr.Length; i++, index++)
                {
                    if (arr[i] == 1)
                        count++;
                    if (count == item)
                        break;

                }
                answer.Add(index);

            }
            
        }
        static int[] Erotosfen(int n)
        {

            int[] S = new int[n+1];
                S[1] = 0; // 1 - не простое число
                          // заполняем решето единицами
                for (int k = 2; k <= n; k++)
                    S[k] = 1;

                for (int k = 2; k * k <= n; k++)
                {
                    // если k - простое (не вычеркнуто)
                    if (S[k] == 1)
                    {
                        // то вычеркнем кратные k
                        for (int l = k * k; l <= n; l += k)
                        {
                            S[l] = 0;
                        }
                    }
                }
                return S;
           
        }
        static void ReadFile()
        {
            list = new List<int>();
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_61\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        var list1 =strRead.ReadLine().Split(' ').Select(Int32.Parse).ToList();
                        foreach (var item in list1)
                        {
                            list.Add(item);
                        }
                        
                    }
                }
            }
        }
    }
}
