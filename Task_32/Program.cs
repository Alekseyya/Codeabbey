using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_32
{
    class Program
    {
        static public int[] arr;
        static public int N { get; set; }
        static public int K { get; set; }
        static void Main(string[] args)
        {
            ReadFile();
            FillArr();
            Josephus();
            Console.WriteLine(arr[0]);
            Console.ReadKey();
        }
        static void Josephus()
        {
            int j = -1;
            while (arr.Length != 1)
            {
                for (int i = 1; i <= K; i++)
                {
                    j++;
                    if (j > arr.Length - 1)
                        j = 0;
                }
                if (arr.Length != 1)
                {
                    arr = arr.Where(indx => indx != arr[j]).ToArray();
                    --j;
                }
            }
        }
        static void FillArr()
        {
            arr = new int[N];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] =i+ 1;
            }
        }
        static void ReadFile()
        {

            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_32\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        int[] str = strRead.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
                        N = str[0];
                        K = str[1];
                    }
                }
            }
        }
    }
}
