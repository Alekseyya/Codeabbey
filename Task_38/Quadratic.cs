using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_38
{
    public class Quadratic
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public bool DiscriminantBool
        {
            get
            {
                
                if (Discriminant >= 0)
                    return true;
                return false;
            }
        }
        public int Discriminant
        {
            get
            {
                return (int)Math.Pow(B, 2) - 4 * A * C;

            }
            
        }
    }
}
