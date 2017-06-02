using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_94
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadFile();
            Console.ReadKey();
        }
        static void ReadFile()
        {
            
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_94\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        var list1 = strRead.ReadLine().Split(' ').Select(Int32.Parse).ToList();
                        int total = 0;
                        foreach (var item in list1)
                        {
                            total += item*item;
                        }
                        Console.Write(total + " ");
                    }
                }
            }
        }
    }
}
