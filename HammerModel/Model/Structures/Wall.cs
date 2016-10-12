using HammerModel.Model;

using HammerModel.Model.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Structures
{
    public class Wall : TextureObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int Width { get; set; }
        public int Breadth { get; set; }
        public int Height { get; set; }
        public double BottomPercentage { get; set; }

        public override List<HammerObject> ToHammerObject()
        {
            List<HammerObject> entityList = new List<HammerObject>();

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
                Texture = TexturePack.WallTexture.Bottom
            };
            Block topCube = new Block
            {
                X = X,
                Y = Y,
                Z = Z + bottomHeight,
                Width = Width,
                Breadth = Breadth,
                Height = topHeight,
                Texture = TexturePack.WallTexture.Top
            };

            entityList.AddRange(bottomCube.ToHammerObject());
            entityList.AddRange(topCube.ToHammerObject());

            return entityList;
        }
    }
}
