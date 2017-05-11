using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_57
{
    class Program
    {
        static public List<double> doubleNumber = new List<double>();
        static void Main(string[] args)
        {
            ReadFile();
            StringBuilder str = new StringBuilder();
            foreach (var item in doubleNumber)
            {
                str.Append(item.ToString(CultureInfo.GetCultureInfo("en-GB")) + " ");
            }
            Console.ReadKey();
        }
        static void SmoothingtheWeather(double[] arrInt)
        {
            double[] doubleNumber1 = new double[arrInt.Length];
            doubleNumber1[0] = arrInt[0];
            doubleNumber1[arrInt.Length-1] = arrInt[arrInt.Length-1];
            for (int i = 1; i < arrInt.Length-1; i++)
            {
                doubleNumber1[i] = (arrInt[i - 1] + arrInt[i] + arrInt[i + 1]) / 3;
            }
            for (int i = 0; i < doubleNumber1.Length; i++)
            {
                doubleNumber.Add(doubleNumber1[i]);
            }
                
            
        }
        static void ReadFile()
        {
            
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_57\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        string[] str = strRead.ReadLine().Split(' ').ToArray();
                        double[] arrDouble = new double[str.Count()];
                        for (int i = 0; i < str.Length; i++)
                        {
                            
                            arrDouble[i] =  Convert.ToDouble(str[i].Replace(".",","));
                        }
                        SmoothingtheWeather(arrDouble);
                    }
                }
            }
        }
    }
}
