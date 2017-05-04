using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_27
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
            Console.ReadKey();
        }
        static void ReadFile()
        {
            numbers = new List<int>();
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Codeabbey\Task_27\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        bool sorted = false;
                        int passcount=0, swapcount =0;
                        int[] arrInt = strRead.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
                        while (!sorted)
                        {
                            sorted = true;
                            for (int i = 0; i < arrInt.Length-1; i++)
                            {
                                
                                if (arrInt[i] > arrInt[i + 1])
                                {

                                    sorted = false;
                                    int tmp = arrInt[i];
                                    arrInt[i] = arrInt[i + 1];
                                    arrInt[i + 1] = tmp;
                                    swapcount++;
                                }
                                

                            }
                            passcount++;
                        }
                        numbers.Add(passcount);
                        numbers.Add(swapcount);
                    }
                }
            }
        }
    }
}
