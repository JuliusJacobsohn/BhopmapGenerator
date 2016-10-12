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
        public override string ToString()
        {
            return "(" + X1 + " " + Y1 + " " + Z1 + ") (" + X2 + " " + Y2 + " " + Z2 + ") (" + X3 + " " + Y3 + " " + Z3 + ")";
        }
    }
}