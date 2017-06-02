using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_42
{
    class Program
    {
        static public char[] list = new char[] { 'T', 'J', 'Q', 'K' };
        static void Main(string[] args)
        {
            ReadFile();
            Console.ReadKey();
        }
        static int MaxSumCard(int result, int countA)
        {
            List<int> arr = new List<int>();

            if (countA > 1)
            {
                //если все A=1
                arr.Add(countA);
                //если один из них будет 11(два по 11 не может быть)
                arr.Add(countA - 1 + 11);
                
            }
            else
            {
                arr.Add(11);
                arr.Add(1);
            }
            List<int> arrMax = new List<int>();
            foreach (var sum in arr)
            {

                if (result + sum <= 21)
                    arrMax.Add(result + sum);
            }
            if (arrMax.Count != 0)
                return arrMax.Max();
            else return result + 11;


        }
        static void ReadFile()
        {
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_42\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        var cards = strRead.ReadLine().Split(' ').ToList();
                        int result = 0;
                        int countA = 0;
                        foreach (var card in cards)
                        {
                            int numberCard = 0;
                            string strCard = String.Empty;
                            if (int.TryParse(card, out numberCard))
                                numberCard=Convert.ToInt32(card);
                            else strCard = card;
                            if (strCard == "A")
                            {
                                countA++;
                                continue;
                            }
                                
                            if (strCard!="" && list.Contains(strCard[0]))
                                result = result + 10;
                            else result = numberCard + result;
                        }
                        if (countA > 0)
                        {
                            result = MaxSumCard(result,countA);
                        }

                        if (result <= 21)
                            Console.Write($"{result} ");
                        else Console.Write("Bust ");
                       

                    }
                }
            }
        }
    }
}
