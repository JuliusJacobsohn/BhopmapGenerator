using HammerModel.Model.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Helpers
{
    public class MatrixHelper
    {
        public static void RotateZ(ValueTriple point, ValueTriple origin = null)
        {
            if (origin != null)
            {

            }
            else
            {

            }
        }

        public class Matrix3D
        {
            public double c11 { get; set; }
            public double c12 { get; set; }
            public double c13 { get; set; }
            public double c21 { get; set; }
            public double c22 { get; set; }
            public double c23 { get; set; }
            public double c31 { get; set; }
            public double c32 { get; set; }
            public double c33 { get; set; }
            public static Matrix3D GetZRotationMatrix(double theta)
            {
                return new Matrix3D
                {
                    c11 = CosDeg(theta),
                    c12 = -SinDeg(theta),
                    c13 = 0,
                    c21 = SinDeg(theta),
                    c22 = CosDeg(theta),
                    c23 = 0,
                    c31 = 0,
                    c32 = 0,
                    c33 = 1
                };
            }

            public static double CosDeg(double theta)
            {
                return Math.Cos(theta * (180.0 / Math.PI));
            }
            public static double SinDeg(double theta)
            {
                return Math.Sin(theta * (180.0 / Math.PI));
            }
        }
    }
}
