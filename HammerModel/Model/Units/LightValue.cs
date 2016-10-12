using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Units
{
    public class LightValue
    {
        public double R { get; set; }
        public double G { get; set; }
        public double B { get; set; }
        public double A { get; set; }
        public override string ToString()
        {
            return R + " " + G + " " + B + " " + A;
        }

        public static LightValue GetDefault()
        {
            return new LightValue
            {
                R = -1,
                B = -1,
                G = -1,
                A = -1
            };
        }
    }
}
