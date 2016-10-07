using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BhopmapGenerator.Model.Structures
{
    public class Cuboid : IWorldObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int Width { get; set; }
        public int Breadth { get; set; }
        public int Height { get; set; }
        public TextureInfo TextureInfo { get; set; }

        public List<Solid> ToWorldObject()
        {
            List<Solid> cubeList = new List<Solid>();

            cubeList.Add(new Solid(X, Y, Z, Width, Breadth, Height, TextureInfo));

            return cubeList;
        }
    }
}
