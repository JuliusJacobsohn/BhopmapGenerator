using HammerModel.Helpers;
using System.Collections.Generic;
using System.Globalization;

namespace HammerModel.Model.Units
{
    public class Axis
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Translation { get; set; }
        public double Factor { get; set; }
        public List<RotationTask> Rotations { get; set; }

        public override string ToString()
        {
            ValueTriple v1 = new ValueTriple { X = X, Y = Y, Z = Z };
            //foreach (var rotationTask in Rotations)
            //{
            //    v1 = MatrixHelper.Rotate(v1, rotationTask);
            //} TODO: Rotate textures properly
            return "[" +
                v1.X.ToString(CultureInfo.InvariantCulture) + " " +
                v1.Y.ToString(CultureInfo.InvariantCulture) + " " +
                v1.Z.ToString(CultureInfo.InvariantCulture) + " " +
                Translation.ToString(CultureInfo.InvariantCulture) + "] " +
                Factor.ToString(CultureInfo.InvariantCulture);
        }
    }
}
