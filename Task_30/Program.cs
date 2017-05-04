using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_30
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "make";
            char[] arrChar = str.ToCharArray();

            arrChar = Reverse(arrChar);
            StringBuilder strNew = new StringBuilder();
            for (int i = 0; i < arrChar.Length; i++)
            {
                strNew.Append(arrChar[i]);
            }
            
        }
        
        static char[] Reverse(char[] ar)
        {
            for (int i = 0, j = ar.Length - 1; i < j; i++, j--)
            {
                char tmp = ar[i];
                ar[i] = ar[j];
                ar[j] = tmp;

            }
            return ar;
        }
    }
}
