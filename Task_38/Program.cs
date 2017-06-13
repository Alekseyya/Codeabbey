using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_38
{
    class Program
    {
        static public List<Quadratic> list = new List<Quadratic>();
        static void Main(string[] args)
        {
            ReadFile();
            Process();
            Console.ReadKey();

        }
        static void Process()
        {
            foreach (var equation in list)
            {
                if (equation.DiscriminantBool)
                {
                    Console.Write((-equation.B + Math.Sqrt(Math.Pow(equation.B, 2) - 4 * equation.A * equation.C)) / (2 * equation.A));
                    Console.Write(" ");
                    Console.Write((-equation.B - Math.Sqrt(Math.Pow(equation.B, 2) - 4 * equation.A * equation.C)) / (2 * equation.A));
                    Console.Write("; ");
                }else
                {
                    int b = -equation.B;
                    int sqrt = (int)Math.Sqrt(equation.Discriminant * -1);
                    int twoA = (2 * equation.A);
                    int imp = b/twoA;
                    int dec = sqrt / twoA;
                    Console.Write($"{imp}+{dec}i ");
                    Console.Write($"{imp}-{dec}i; ");

                }
            }
        }
        static void ReadFile()
        {
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_38\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        List<int> temp = strRead.ReadLine().Split(' ').Select(Int32.Parse).ToList();
                        list.Add(new Quadratic { A = temp[0], B = temp[1], C = temp[2] });
                    }
                }
            }
        }
    }
}
