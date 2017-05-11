using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_19
{
    class Program
    {
        static public List<int> list = new List<int>();
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

        static void Regex(string str)
        {
            string patern = @"[(){}<>\[\]]";
            Regex reg = new Regex(patern);
            MatchCollection matches = reg.Matches(str);
            StringBuilder strNew = new StringBuilder();
            if (matches.Count > 0)
            {
                foreach (var item in matches)
                {
                    strNew.Append(item);
                }
                
            }

            int old_len = strNew.Length + 1;

            while (strNew.Length<old_len)
            {
                old_len = strNew.Length;
                strNew = strNew.Replace("()", "").Replace("{}", "").Replace("[]", "").Replace("<>", "");

            }
            if (strNew.Length > 0)
            {
                list.Add(0);
            }
            else list.Add(1);
            
            
        }
        static void ReadFile()
        {

            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_19\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        
                        Regex(strRead.ReadLine());
                       
                    }
                }
            }
        }
    }
}
