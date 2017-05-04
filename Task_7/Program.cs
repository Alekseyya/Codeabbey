using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


//правильная формула cels = 5 * (fahr - 32) / 9
namespace Task_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex reg = new Regex(@"[-0-9]+");
            string pars = @"36 470 514 156 365 318 477 47 228 418 518 312 194 108 45 356 302 216 269 297 355 188 72 252 419 183 371 164 279 222 364 68 92 278 192 426 564";

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
            for (int i = 1; i <= arrPar[0]; i++)
            {
                //double c = 5.0 / 9.0 * (f - 32);
                result.Append(Math.Round( 5.0 / 9.0 * (arrPar[i] - 32), MidpointRounding.AwayFromZero) + " ");
                
            }
            var t = 0;
        }
    }
}
