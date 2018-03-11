using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranging
{
    public class BordAlt
    {
        public int Value { get; set; }
        public int Sign { get; set; } //1 больше, 2 равно, 0 конец
        public double Grade { get; set; }

        public BordAlt() { }
        public BordAlt(int value, int sign)
        {
            this.Value = value;
            this.Sign = sign;
        }
    }
}
