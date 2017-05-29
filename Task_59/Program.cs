using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_59
{
    class Program
    {
        static public List<int> list;
        static void Main(string[] args)
        {
            ReadFile();
            Mastermind(9431);
        }
        public static int[] digitArr(int n)
        {
            if (n == 0) return new int[1] { 0 };

            var digits = new List<int>();

            for (; n != 0; n /= 10)
                digits.Add(n % 10);

            var arr = digits.ToArray();
            Array.Reverse(arr);
            return arr;
        }

        static void Mastermind(int secretValue)
        {
            int[] arr = digitArr(secretValue);

            int mk1 = 0; //первый элемент
            foreach (var mk in list)
            {
                //Первая подсказка
                List<int> saveNumbers = new List<int>();
                
                int countHintOne = 0;
                int[] arrPass = digitArr(mk);
                for (int ik = 0, jk = 0; ik < arr.Count() & jk < arr.Count(); ik++, jk++)
                {
                    if (arr[ik] == arrPass[jk])
                    {
                        saveNumbers.Add(arr[ik]);
                        countHintOne++;
                    }
                    
                }

                //вторая подсказка
                int countHintTwo = 0;
                for (int i = 0; i < arr.Count(); i++)
                {
                    if (SaveNumbers(saveNumbers, arr[i]))
                        continue;
                    for (int j = 0; j < arr.Count(); j++)
                    {
                        if (SaveNumbers(saveNumbers, arr[j]))
                            continue;
                        if (arr[i] == arrPass[j])
                            countHintTwo++;
                    }

                }

                Console.Write($"{countHintOne}-{countHintTwo} ");
            }
            Console.ReadKey();
        }

        static bool SaveNumbers(List<int> saveNumbers, int number)
        {
            foreach (var item in saveNumbers)
            {
                if (item == number)
                    return true;
            }
            return false;
        }
        static void ReadFile()
        {
            list = new List<int>();
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_59\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        var list1 = strRead.ReadLine().Split(' ').Select(Int32.Parse).ToList();
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
