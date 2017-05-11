using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_50
{
    class Program
    {
        private static List<string> numbers;

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
        static string Reverse(string str)
        {
            char[] charArr = str.ToCharArray();
            for (int i = 0 , j=str.Count()-1; i < j; i++, j--)
            {
                char tmp = charArr[i];
                charArr[i] = charArr[j];
                charArr[j] = tmp;
            }
            return new string(charArr);
        }
        static bool Palindromes(string str)
        {
            
            if (str != Reverse(str))
                return false;
            return true;
        }
        static void ReadFile()
        {
            numbers = new List<string>();
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_50\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        string str = strRead.ReadLine().ToLower();
                        string strn = str.Replace(",", "").Replace(".", "").Replace("!", "").Replace("?", "").Replace(" ", "").Replace("-","");
                        numbers.Add(Palindromes(strn) ? "Y":"N");
                    }
                }
            }
        }
    }
}
