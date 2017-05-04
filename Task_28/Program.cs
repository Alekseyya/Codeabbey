using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Входные данные - указывают количество человек (подопытных!) в первой строке.
/// Остальные строки содержат параметры одного человека каждая - вес в килограммах и рост в метрах.
/// Ответ должен содержать одно из слов under, normal, over, obese(см.категории выше) для каждого из исследуемых людей, через пробел.
/// </summary>

namespace Task_28
{
    class Program
    {
        public static List<string> numbers;

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
        static string BodyMaxIndex(int weight, double height)
        {
            double bmi = (double )weight / Math.Pow(height,2);

            if(bmi>0 && bmi < 18.5)
                         return "under";
             if(bmi>=18.5 && bmi < 25.0)
                         return "normal";
            
            if(bmi>=25.0 && bmi < 30)
                         return "over";
            if (bmi >= 30)
                return "obese";
            return "Что-то не так!";
        }
        static void ReadFile()
        {
            numbers = new List<string>();
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\1\Codeabbey\Task_28\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        string[] arrdata = strRead.ReadLine().Split(' ');
                        int weight = Convert.ToInt32(arrdata[0]);
                        double height = double.Parse(arrdata[1], System.Globalization.CultureInfo.InvariantCulture);
                        numbers.Add(BodyMaxIndex(weight, height));
                    }
                }
            }
        }
    }
}
