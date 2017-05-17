using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_55
{
    //Взят алгоримт Кнута-Мориса-Прата
    class Program
    {
        static public List<string> list;
        static public List<string> repeatlist;
        static void Main(string[] args)
        {
            ReadFile();
            RepeatedString();
            BubleSort();
            Print();
            //string tar = "san and linux training";

            //string pat = "sa";

            //if (KMP(pat, tar))
            //    Console.WriteLine("есть");

            //else
            //    Console.WriteLine("нету");

            //string s1 = "bb";
            //string s2 = "aa";
            //int r = s1.CompareTo(s2);
            //if (r < 0)
            //{
            //    Console.WriteLine("Совпадение строк");
            //}
            //else Console.WriteLine("Несовпадение строк");

        }

        static void Print()
        {
            foreach (var item in repeatlist)
            {
                Console.Write(item + " ");
            }
            Console.ReadKey();
        }

        static void BubleSort()
        {
            repeatlist = repeatlist.Distinct().ToList();
            bool flag = false;

            while (!flag)
            {
                flag = true;
                for (int i = 0; i < repeatlist.Count-1; i++)
                {
                    int r = repeatlist[i].CompareTo(repeatlist[i + 1]);
                    if (r > 0)
                    {
                        flag = false;
                        Swap(i, i + 1);
                    }
                       
                }
            }
        }

        static void RepeatedString()
        {
            repeatlist = new List<string>();
            List<string> tmp = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                tmp.Add(list[i]);
            }
            int iter = 0;
            foreach (var item in list)
            {
                tmp.RemoveAt(iter);
                string str = string.Join(" ", tmp.ToArray());
                if (KMP(item, str))
                    repeatlist.Add(item);
                

            }
          
        }

        static void preKMP(string pattern, int[] f)
        {
            int m = pattern.Length, k;
            f[0] = -1;
            for (int i = 1; i < m; i++)
            {
                k = f[i - 1];
                while (k >= 0)
                {
                    if (pattern[k] == pattern[i - 1])

                        break;
                    else
                      k = f[k];
                }
                f[i] = k + 1;
            }

        }



        //check whether target string contains pattern 

        static bool KMP(string pattern, string target)
        {
            int m = pattern.Length;
            int n = target.Length;
            int[] f = new  int[m];
            preKMP(pattern, f);
            int i = 0;
            int k = 0;
            while (i < n)
            {
                if (k == -1)
                {
                    i++;
                    k = 0;
                }
                else if (target[i] == pattern[k])
                {
                    i++;
                    k++;
                    if (k == m)
                        return true; //false
                }
                else
                    k = f[k];

            }
            return false; //true

        }

        static void Swap(int i, int j)
        {
            var t = repeatlist[i];
            repeatlist[i] = repeatlist[j];
            repeatlist[j] = t;
        }
        static void ReadFile()
        {
            list = File.ReadAllText(@"C:\Work\Codeabbey\Task_55\file.txt", Encoding.UTF8).Split(' ').ToList();
           
            //using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_55\file.txt", FileMode.Open, FileAccess.Read))
            //{
            //    using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
            //    {
            //        while (!strRead.EndOfStream)
            //        {
            //            list = strRead.ReadLine().Split(' ').ToList();
                        
            //        }
            //    }
            //}
        }
    }

}
