using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_49
{
    class Program
    {
        static public List<List<string>> list;
        static public List<int> won = new List<int>();
        static void Main(string[] args)
        {
            ReadFile();
            RockPaper();
            Print();
        }
        static void Print()
        {
            foreach (var player in won)
            {
                Console.Write(player + " ");
            }
            Console.ReadKey();
        }
        static void RockPaper()
        {
            
            for (int numberString = 0; numberString < list.Count; numberString++)
            {
                //счетчик количества выигрывания
                int countWonFirstPlayer = 0;
                int countWonSecondPlayer = 0;
                for (int numberElement = 0; numberElement < list[numberString].Count; numberElement++)
                {
                    char[] massiveGame = list[numberString][numberElement].ToCharArray();
                    //если выйграл
                    int resultWon = WonPlayer(massiveGame[0], massiveGame[1]);
                    if (resultWon == 1)
                        countWonFirstPlayer++;
                    else if(resultWon==2)
                        countWonSecondPlayer++;
                    
                }
                if (countWonFirstPlayer > countWonSecondPlayer)
                    won.Add(1);
                else won.Add(2);
            }
        }
        static int WonPlayer(char firstPlayer, char secondPlayer)
        {
            if ((firstPlayer == 'R' && secondPlayer == 'S') | (firstPlayer == 'S' && secondPlayer == 'P') | (firstPlayer == 'P' && secondPlayer == 'R'))
                return 1; //если выйграл первый игрок возвращаем 1
            else if ((firstPlayer == 'R' && secondPlayer == 'R') | (firstPlayer == 'S' && secondPlayer == 'S') | (firstPlayer == 'P' && secondPlayer == 'P'))
                return 0;
            return 2; //если выйграл второй игрок возвращаем 2
        }
        static void ReadFile()
        {
            list = new List<List<string>>();
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_49\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        list.Add(strRead.ReadLine().Split(' ').ToList());

                    }
                }
            }
        }

    }
}
