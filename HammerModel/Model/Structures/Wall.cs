using HammerModel.Model;

using HammerModel.Model.Structures;
using HammerModel.Model.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Structures
{
    public class Wall : TextureObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Width { get; set; }
        public double Breadth { get; set; }
        public double Height { get; set; }
        public double BottomPercentage { get; set; }

        public override List<HammerObject> ToHammerObject()
        {
            List<HammerObject> entityList = new List<HammerObject>();

            double bottomHeight = (int)(Height * BottomPercentage);
            double topHeight = Height - bottomHeight;

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

            bottomCube.AddRotationTask(Rotations);
            topCube.AddRotationTask(Rotations);

            entityList.AddRange(bottomCube.ToHammerObject());
            entityList.AddRange(topCube.ToHammerObject());

            return entityList;
        }

        public override ValueTriple GetOrigin()
        {
            return new ValueTriple
            {
                X = X + Width / 2,
                Y = Y + Breadth / 2,
                Z = Z + Height / 2
            };
        }
    }
}
