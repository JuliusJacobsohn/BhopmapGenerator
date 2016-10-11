using HammerModel.Model;
using HammerModel.Model.Misc;
using HammerModel.Model.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Structures
{
    public class Wall : IWorldObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int Width { get; set; }
        public int Breadth { get; set; }
        public int Height { get; set; }
        public double BottomPercentage { get; set; }
        public WallTextureInfo WallTexture { get; set; }

        public List<Solid> ToWorldObject()
        {
            List<Solid> cubeList = new List<Solid>();

            int bottomHeight = (int)(Height * BottomPercentage);
            int topHeight = Height - bottomHeight;

            Block bottomCube = new Block
            {
                X = X,
                Y = Y,
                Z = Z,
                Width = Width,
                Breadth = Breadth,
                Height = bottomHeight,
                TextureInfo = WallTexture.Bottom
            };
            Block topCube = new Block
            {
                X = X,
                Y = Y,
                Z = Z + bottomHeight,
                Width = Width,
                Breadth = Breadth,
                Height = topHeight,
                TextureInfo = WallTexture.Top
            };

            cubeList.AddRange(bottomCube.ToWorldObject());
            cubeList.AddRange(topCube.ToWorldObject());

            return cubeList;
        }
    }
}
