using System.Globalization;

namespace HammerModel.Model.Units
{
    public class Axis
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public double Translation { get; set; }
        public double Factor { get; set; }
        public override string ToString()
        {
            return "[" + X + " " + Y + " " + Z + " " + Translation.ToString(CultureInfo.InvariantCulture) + "] " + Factor.ToString(CultureInfo.InvariantCulture);
        }
    }
}
