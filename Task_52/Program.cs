using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_52
{
    class Program
    {
        static public List<string> list = new List<string>();

        static public int a { get; set; }
        static public int b { get; set; }
        static public int c { get; set; }
        static void Main(string[] args)
        {
            ReadFile();
            StringBuilder str = new StringBuilder();
            foreach (var item in list)
            {
                str.Append(item + " ");
            }
            Console.ReadKey();
        }
        static void ReadFile()
        {

            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_52\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        int[] str = strRead.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
                        a = str[0];
                        b = str[1];
                        c = str[2];
                        if(a*a+b*b == c * c)
                        {
                            list.Add("R");
                        }else if(a*a+b*b > c * c)
                        {
                            list.Add("A");
                        }else if(a*a+b*b< c * c)
                        {
                            list.Add("O");
                        }
                    }
                }
            }
        }
    }
}
