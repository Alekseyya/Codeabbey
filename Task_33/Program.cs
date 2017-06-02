using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_33
{
    class Program
    {
        static public List<int> list;
        static void Main(string[] args)
        {
           
            ReadFile();
            Test();
        }

        static void Test()
        {
            StringBuilder str = new StringBuilder();
            foreach (int number in list)
            {
                string byteString = NumberToBiinaryString(number);
                int cout1 = byteString.Select(x => x == 1).Count();
                if(byteString.ToCharArray().Where(x => x == '1').Count() % 2 == 0)
                {
                    string amendedByteString = String.Empty;
                    int output = 0;

                    amendedByteString = ChangeFistByte(byteString, 0);
                    output = Convert.ToInt32(amendedByteString, 2);

                    if (TestSymbol(output))
                    {                       
                        str.Append(NumberAsciiToChar(output));
                    }
                }
                
            }
            Console.WriteLine(str);
            Console.ReadKey();
        }
        static char NumberAsciiToChar(int number)
        {
            return (char)number;
        }
        static bool TestSymbol(int number)
        {
            if (!((number >= 65 & number <= 90) | (number >= 97 & number <= 122) | number==46 | number==32 | (number >= 48 & number <= 57)))
                return false;
            return true;
        }
        static string NumberToBiinaryString(int number)
        {
          //int output = Convert.ToInt32(binary, 2);            
          return Convert.ToString(number, 2).PadLeft(8, '0');
        }
        static string ChangeFistByte(string binaryString, int nbyte)
        {
                StringBuilder str = new StringBuilder(binaryString);
                str.Remove(0, 1);
                str.Insert(nbyte, 0);
            
            return str.ToString();
        }
        static void ReadFile()
        {
          
            using (FileStream filestr = new FileStream(@"C:\Work\Codeabbey\Task_33\file.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader strRead = new StreamReader(filestr, Encoding.UTF8))
                {
                    while (!strRead.EndOfStream)
                    {
                        list = strRead.ReadLine().Split(' ').Select(Int32.Parse).ToList();
                        
                    }
                }
            }
        }
    }
}
