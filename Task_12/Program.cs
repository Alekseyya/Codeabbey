using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Modulo and time difference
/// <summary>
/// Входные данные - в первой строке указано количество тестов, а в остальных идут сами тесты, по одному в каждой.
/// Каждый тест состоит из 8 чисел, по 4 для каждой из двух меток: день1 час1 мин1 сек1 день2 час2 мин2 сек2(ворая метка всегда будет позже первой по времени).
/// Ответ для каждого теста должен содержать разность в виде(days hours minutes seconds) - обратите внимание на скобки - с пробелами между результатами.
/// </summary>

namespace Task_12
{
    class Program
    {
        static List<Day> numbers;
        static void Main(string[] args)
        {
            ReadFile();
            StringBuilder str = new StringBuilder();
            foreach (var item in numbers)
            {
                str.Append("(" + item.Days + " " + item.Hourse + " " + item.Minutes + " " + item.Seconds + ")" + " ");
            }
            Console.ReadKey();
        }
        static int ModuloAndTimeDifference(int[]firstDay, int[]secondDay)
        {
            int summTimesOfFirstDay = SummTimesOfDay(firstDay);
            int summTimesOfSecondDay = SummTimesOfDay(secondDay);
            return summTimesOfSecondDay - summTimesOfFirstDay;
        }
        static int SummTimesOfDay(int[] day)
        {
            
            int days = day[0] * 24 * 60 * 60;
            int hourses = day[1] * 60 * 60;
            int minutes = day[2] * 60;
            int secundes = day[3];
            return days + hourses + minutes + secundes;
        }
        static Day TimeDifference(int difference)
        {
            Day day = new Day();
            day.Days = difference / (24 * 60 * 60);  //1
            day.Hourse = (difference - ((24 * 60 * 60) * day.Days))/ (60*60); //3
            day.Minutes = ((difference - ((24 * 60 * 60) * day.Days)) - ((60 * 60) * day.Hourse))/60; //4
            day.Seconds = ((difference - ((24 * 60 * 60) * day.Days)) - ((60 * 60) * day.Hourse)) - (60 * day.Minutes); //5
            return day;

        }
        static void ReadFile()
        {
            numbers = new List<Day>();
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\1\Codeabbey\Task_12\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        int[] arrInt = strRead.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
                        int[] firstDay = arrInt.Take(4).ToArray();
                        int[] secondDay = arrInt.Skip(4).Take(4).ToArray();
                        int difference = ModuloAndTimeDifference(firstDay, secondDay);
                        numbers.Add(TimeDifference(difference));
                    }
                }
            }
        }
    }
}
