using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_31
{
    class Program
    {
        private static List<string> listString;

        static void Main(string[] args)
        {
            ReadFile();
            StringBuilder str = new StringBuilder();
            foreach (var item in listString)
            {
                str.Append(item + " ");
            }
            Console.ReadKey();
        }
        
        static string RotateString(string[] str)
        {
            char[] cheArr = str[1].ToCharArray();
            int rotate = Convert.ToInt16(str[0]) > 0 ? 0 : str[1].Length - 1;

            for (int i = 1; i <= Math.Abs(Convert.ToInt16(str[0])); i++)
            {
                if (rotate == 0)
                {
                    char tmp = cheArr[rotate];
                    int numIndex = Array.IndexOf(cheArr, tmp);
                    cheArr = cheArr.Where((val, idx) => idx != numIndex).ToArray();
                    Array.Resize(ref cheArr, cheArr.Length + 1);
                    cheArr[cheArr.Length - 1] = tmp;
                }else
                {
                    char tmp = cheArr[cheArr.Length - 1];
                    int numIndex = Array.LastIndexOf(cheArr, tmp);
                    //cheArr = cheArr.Where((val, idx) => idx != numIndex).ToArray();
                    List<char> list = cheArr.ToList();
                    list.RemoveAt(numIndex);
                    list.Insert(0, tmp); 
                    cheArr = list.ToArray();
                }
            }
            return new string(cheArr);

        }
        static void ReadFile()
        {
            listString = new List<string>();
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_31\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        string[] str = strRead.ReadLine().Trim().ToLower().Split(' ');
                        listString.Add(RotateString(str));
                    }
                }
            }
        }
    }
}
