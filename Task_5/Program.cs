using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int countpar = 26;
            Regex reg = new Regex(@"[-0-9]+");
            string pars = @"
6227102 -5394334 5593970
-2922561 8972082 -5811577
-3912832 -7728440 -1216044
6223934 -2998072 -7736356
-6705634 -9841345 5901424
-7193139 -469757 -5585776
-8489959 -3864229 -2313963
825527 5552097 -917541
2282543 1320437 -5156995
-7610015 -9575205 -2684680
5090233 6651897 1920986
684203 -6270663 893069
4872625 -183496 3164628
-6343419 -3959561 -9833444
-4079775 -665196 -9674789
-8178351 2141665 -144546
-3764127 3651705 5991224
3921909 -5522767 1543321
-6995631 6759775 -7136242
-2152627 9149760 -6711447
5162693 4239993 9940449
-2916320 -5075804 -6330213
7976748 9796821 3486290
1141376 -6546597 9526729
1307932 -626373 -1138467
1633142 1195276 -8996802";

            MatchCollection arrPar1 = reg.Matches(pars);
            int[] arrPar = new int[arrPar1.Count];
            int iter = 0;
            foreach (Match elem in arrPar1)
            {
                arrPar[iter] = Convert.ToInt32(elem.Value);
                iter++;
            }
            int min = 0;
            int k = 0;
            StringBuilder result = new StringBuilder();
           var t = Math.Min(10, Math.Min(3, 4));
            for (int i = 0; i < countpar; i++)
            {
                
                min = Math.Min(arrPar[k], Math.Min(arrPar[k + 1], arrPar[k + 2]));
                k += 3;
                result.Append(min + " ");
            }

            Console.ReadKey();
        }
    }
}
