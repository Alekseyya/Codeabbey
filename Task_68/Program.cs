﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_68
{
    class Program
    {
        static public int S { get; set; }
        static public int A { get; set; }
        static public int B { get; set; }
        static public List<string> list = new List<string>();
        static void Main(string[] args)
        {
            ReadFile();
            Print();
        }
        static void Print()
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.ReadKey();
        }
        static int Count(double result)
        {
            int tmp = (int)result;
            int count = 0;
            while (tmp != 0)
            {
                count++;
                tmp = tmp / 10;
            }
            return count;
        }
        static void BRace()
        {
            double result = (double)S / (A + B);
            result = result * A;
            int count = Count(result);
            
            list.Add(Math.Round(result, 12- count).ToString(CultureInfo.GetCultureInfo("en-GB")));
        }
        static void ReadFile()
        {

            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_68\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        int[] str = strRead.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
                        S = str[0];
                        A = str[1];
                        B = str[2];
                        BRace();
                    }
                }
            }
        }
    }
}
