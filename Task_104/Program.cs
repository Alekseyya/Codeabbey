using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_104
{
    class Program
    {
        static public List<int[]> listMassive;
        static public List<double> answers = new List<double>();
        static void Main(string[] args)
        {
            
            ReadFile();
            Gerone();
            Print();


        }
        static void Print()
        {
            
            foreach (var item in answers)
            {
                Console.Write(item.ToString().Replace(",", ".") + " ");
            }
            Console.ReadKey();
        }
        static void Gerone()
        {
            for (int i = 0; i < listMassive.Count; i++)
            {
                //расстояние между точками 
                //(x2 - x1)**2 + (y2-y1)**2
                double a = Math.Sqrt(Math.Pow((listMassive[i][2] - listMassive[i][0]),2) + Math.Pow((listMassive[i][3] - listMassive[i][1]),2));
                //(x3 - x1)**2 + (y3-y1)**2
                double b = Math.Sqrt(Math.Pow((listMassive[i][4] - listMassive[i][0]),2) + Math.Pow((listMassive[i][5] - listMassive[i][1]),2));
                //(x3 - x2)**2 + (y3-y2)**2
                double c = Math.Sqrt(Math.Pow((listMassive[i][4] - listMassive[i][2]),2)  + Math.Pow((listMassive[i][5] - listMassive[i][3]),2));
                //полупериметр
                double p = (a + b + c) / 2;
                //формула герона
                double gerone = Math.Sqrt(p * ((p - a) * (p - b) * (p - c)));
                answers.Add(Math.Round(gerone,1));
            }
            
        }
        static void ReadFile()
        {
            listMassive = new List<int[]>();
           using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_104\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        listMassive.Add(strRead.ReadLine().Split(' ').Select(Int32.Parse).ToArray());

                    }
                }
            }
        }
    }
}
