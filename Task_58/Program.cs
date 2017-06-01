using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_58
{
    class Program
    {
        static public string[] suits = new string[4] { "Clubs", "Spades", "Diamonds", "Hearts" };
        static public string[] ranks = new string[13] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
        static void Main(string[] args)
        {
            ReadFile();
            Console.ReadKey();
        }
        static void ReadFile()
        {
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_58\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        var cards = strRead.ReadLine().Split(' ').Select(Int32.Parse).ToList();
                        int suite_value = 0, rank_value = 0;
                        string suit = String.Empty,rank= String.Empty;
                        foreach (var card in cards)
                        {
                            suite_value = card / 13;
                            rank_value = card % 13;
                            suit = suits[suite_value];
                            rank = ranks[rank_value];
                            Console.Write($"{rank}-of-{suit} ");
                        }
                        
                    }
                }
            }
        }
    }
}
