using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HammerModel.Model.Units;
using HammerModel.Model.Entities;

namespace HammerModel.Model.Structures
{
    public class Portal : TextureObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Width { get; set; }
        public double Breadth { get; set; }
        public double Height { get; set; }
        public string Destination { get; set; }

        public override ValueTriple GetOrigin()
        {
            return new ValueTriple
            {
                X = X + Width / 2,
                Y = Y + Breadth / 2,
                Z = Z + Height / 2
            };
        }

        public override List<HammerObject> ToHammerObject()
        {
            List<HammerObject> objectList = new List<HammerObject>();
            Block rightBar = new Block
            {
                X = X,
                Y = Y,
                Z = Z,
                Width = Width,
                Breadth = Width,
                Height = Height-Width,
                Texture = TexturePack.PortalTexture
            };
            Block leftBar = new Block
            {
                X = X,
                Y = Y + Breadth - rightBar.Width,
                Z = Z,
                Width = Width,
                Breadth = Width,
                Height = Height-Width,
                Texture = TexturePack.PortalTexture
            };
            Block topBar = new Block
            {
                X = X,
                Y = Y,
                Z = Z + rightBar.Height,
                Width = Width,
                Breadth = Breadth,
                Height = Width,
                Texture = TexturePack.PortalTexture
            };
            Teleport tp = new Teleport
            {
                X = X,
                Y = Y + rightBar.Width,
                Z = Z,
                Width = Width,
                Breadth = Breadth - (rightBar.Breadth + leftBar.Breadth),
                Height = Height - topBar.Height,
                Target = Destination
            };

            rightBar.AddRotationTask(Rotations);
            leftBar.AddRotationTask(Rotations);
            topBar.AddRotationTask(Rotations);
            tp.AddRotationTask(Rotations);

            objectList.AddRange(rightBar.ToHammerObject());
            objectList.AddRange(leftBar.ToHammerObject());
            objectList.AddRange(topBar.ToHammerObject());
            objectList.AddRange(tp.ToHammerObject());

            return objectList;
        }
    }
}