using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_6
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int countpar = 16;
            Regex reg = new Regex(@"[-0-9]+");
            string pars = @"-2694319 -2736913
4653378 -2302645
5543 1726
8496258 381
4759 660
6029370 124
17363 1642
18639 1218
9338695 1884747
2625213 82
16147 1116
4743524 180
-1996220 -2239288
4634034 109
-7168978 -3435704
8649 1544";

            MatchCollection mathColl = reg.Matches(pars);
            int[] arrPar = new int[mathColl.Count];
            int iter = 0;
            StringBuilder result = new StringBuilder();
            foreach (Match elem in mathColl)
            {
                
                arrPar[iter] = Convert.ToInt32(elem.Value);
                iter++;
            }
            int k = 0;
            for (int i = 0; i < countpar; i++)
            {
                result.Append(Math.Round((double)arrPar[k]/arrPar[k+1], MidpointRounding.AwayFromZero) + " ");
                k += 2;
            }
            var t = result;
        }
    }
}
