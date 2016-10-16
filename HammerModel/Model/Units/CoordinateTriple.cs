using HammerModel.Helpers;
using System.Collections.Generic;
using System.Globalization;

namespace HammerModel.Model.Units
{
    public class CoordinateTriple
    {
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double Z1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }
        public double Z2 { get; set; }
        public double X3 { get; set; }
        public double Y3 { get; set; }
        public double Z3 { get; set; }
        public List<RotationTask> Rotations { get; set; }

        public override string ToString()
        {
            ValueTriple c1 = new ValueTriple { X = X1, Y = Y1, Z = Z1 };
            ValueTriple c2 = new ValueTriple { X = X2, Y = Y2, Z = Z2 };
            ValueTriple c3 = new ValueTriple { X = X3, Y = Y3, Z = Z3 };
            foreach (var rotationTask in Rotations)
            {
                c1 = MatrixHelper.Rotate(c1, rotationTask);
                c2 = MatrixHelper.Rotate(c2, rotationTask);
                c3 = MatrixHelper.Rotate(c3, rotationTask);
            }
            return "(" +
                c1.X.ToString(CultureInfo.InvariantCulture) +
                " " +
                c1.Y.ToString(CultureInfo.InvariantCulture) +
                " " +
                c1.Z.ToString(CultureInfo.InvariantCulture) +
                ") (" +
                c2.X.ToString(CultureInfo.InvariantCulture) +
                " " +
                c2.Y.ToString(CultureInfo.InvariantCulture) +
                " " +
                c2.Z.ToString(CultureInfo.InvariantCulture) +
                ") (" +
                c3.X.ToString(CultureInfo.InvariantCulture) +
                " " +
                c3.Y.ToString(CultureInfo.InvariantCulture) +
                " " +
                c3.Z.ToString(CultureInfo.InvariantCulture) +
                ")";
        }
    }
}