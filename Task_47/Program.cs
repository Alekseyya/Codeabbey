using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_47
{
    class Program
    {
        //Список всех строк
        static public List<string> listStr = new List<string>();
        static public List<StringBuilder> answerList = new List<StringBuilder>();
        static public int k=6;
        static void Main(string[] args)
        {
            ReadFile();
            SplitStr();
            Print();
            Console.ReadKey();
        }
        static void Print()
        {
            foreach (var item in answerList)
            {
                Console.Write(item + " ");
            }
            Console.ReadKey();
        }
        //функция разбра прездожения
        static void SplitStr()
        {
            
            foreach (var str in listStr)  //берем каждое предложение
            {
                StringBuilder resultString = new StringBuilder();
                foreach (char charStr in str) //получаем каждый символ
                {
                    if (charStr == ' ' | charStr == '.')
                    {
                        resultString.Append(charStr);
                        continue;
                    }
                        
                    int ASCIINuberChar = (int)charStr;
                    char resChar = charStr;
                    int kf = 0;
                    for (int i = 1; i <= k; i++)
                    {
                        
                        if (resChar == 'A')
                        {
                            ASCIINuberChar = 90;
                            kf = i;
                        }
                        resChar = (char)(ASCIINuberChar - i + kf);

                    }
                    resultString.Append(resChar);
                }
                
                answerList.Add(resultString);
            }
            
        }
        static void ReadFile()
        {
            
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_47\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        listStr.Add(strRead.ReadLine());

                    }
                }
            }
        }
    }
}
