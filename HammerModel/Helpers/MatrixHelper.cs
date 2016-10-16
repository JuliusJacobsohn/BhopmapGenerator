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
        public static ValueTriple Rotate(ValueTriple point, RotationTask task)
        {
            if (task.Origin != null)
            {
                ValueTriple transformedPoint = new ValueTriple
                {
                    X = point.X - task.Origin.X,
                    Y = point.Y - task.Origin.Y,
                    Z = point.Z - task.Origin.Z
                };
                ValueTriple rotatedPoint = Matrix3D.VectorMult(Matrix3D.GetZRotationMatrix(task.Degree), transformedPoint);
                return new ValueTriple
                {
                    X = rotatedPoint.X + task.Origin.X,
                    Y = rotatedPoint.Y + task.Origin.Y,
                    Z = rotatedPoint.Z + task.Origin.Z
                };
            }
            else
            {
                string test = Matrix3D.GetZRotationMatrix(task.Degree).ToString();
                return Matrix3D.VectorMult(Matrix3D.GetZRotationMatrix(task.Degree), point);
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

            public override string ToString()
            {
                return "Matrix{" + c11 + ", " + c12 + ", " + c13 + "\n" +
                     c21 + ", " + c22 + ", " + c23 + "\n" +
                     c31 + ", " + c32 + ", " + c33 + "}";
            }

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

            public static ValueTriple VectorMult(Matrix3D matrix, ValueTriple vector)
            {
                return new ValueTriple
                {
                    X = matrix.c11 * vector.X + matrix.c12 * vector.Y + matrix.c13 * vector.Z,
                    Y = matrix.c21 * vector.X + matrix.c22 * vector.Y + matrix.c23 * vector.Z,
                    Z = matrix.c31 * vector.X + matrix.c32 * vector.Y + matrix.c33 * vector.Z
                };
            }

            public static double CosDeg(double theta)
            {
                double val = Math.Cos(Math.PI * theta / 180.0);
                return val;
            }
            public static double SinDeg(double theta)
            {
                return Math.Sin(Math.PI * theta / 180.0);
            }
        }
    }
}
