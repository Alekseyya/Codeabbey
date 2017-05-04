using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_20
{
    class Program
    {
        static int counter = 19;
        static List<int> numbers;
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
        static int RegexStr(string regexString)
        {
            
            Regex reg = new Regex(@"[a, o, u, i, e, y]");
            MatchCollection matches = reg.Matches(regexString);
            if (matches.Count > 0)
            {
                return matches.Count;
               
            }
            else
            {
                Console.WriteLine("ничего не нашло");
                return 0;
                
            }
        }
        static void ReadFile()
        {
            numbers = new List<int>();
            using(FileStream filestr = new FileStream(@"C:\Work\Codeabbey\1\Codeabbey\Task_20\file.txt", FileMode.Open, FileAccess.Read))
            {
                using(StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        numbers.Add(RegexStr(Regex.Replace(strRead.ReadLine(), @"\s+", "")));
                    }
                }
            }
        }
    }
}
