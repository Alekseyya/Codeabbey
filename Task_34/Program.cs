using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_34
{
    class Program
    {
        static public List<List<double>> list = new List<List<double>>();
        static void Main(string[] args)
        {

            ReadFile();
            binary();
            Console.ReadKey();
        }
        static void binary()
        {
            foreach (var item in list)
            {
                double presentValue = 100;
                double xMinValue = 0;
                var a = item[0];
                var b = item[1];
                var c = item[2];
                var d = item[3];
                double xMiddle = presentValue;
                double tmp = 0;
                while (true)
                {
                    if (monotonusFunction(xMiddle, a, b, c, d) > 0)
                    {
                        tmp = xMiddle;
                        xMiddle = (xMinValue + xMiddle) / 2;

                    }
                    else
                    {
                        xMiddle = (tmp + xMiddle) / 2;
                        
                    }
                    if (monotonusFunction(xMiddle, a, b, c, d) == 0)
                    {
                        break;
                    }
                }
                Console.Write(xMiddle.ToString().Replace(",", ".") + " ");
            }

        }
        static double monotonusFunction(double x, double a, double b, double c, double d)
        {
            return Math.Round(a * x + b * Math.Sqrt(Math.Pow(x, 3)) - c * Math.Exp(-x / 50) - d,7);
        }
        static void ReadFile()
        {
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_34\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        List<double> temp = strRead.ReadLine().Replace(".", ",").Split(' ').Select(Double.Parse).ToList();
                        list.Add(temp);
                    }
                }
            }
        }
    }
}
