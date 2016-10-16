using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Units
{
    public class RotationTask
    {
        public RotationType RotationType { get; set; }
        public double Degree { get; set; }
        public ValueTriple Origin = new ValueTriple();
    }

    public enum RotationType
    {
        X = 0,
        Y = 1,
        Z = 2
    }
}
