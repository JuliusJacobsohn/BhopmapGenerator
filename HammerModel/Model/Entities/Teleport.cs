
using HammerModel.Model.Structures;
using HammerModel.Model.Textures;
using HammerModel.Model.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Entities
{
    public class Teleport : WorldObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Width { get; set; }
        public double Breadth { get; set; }
        public double Height { get; set; }
        public string Target { get; set; }

        public override List<HammerObject> ToHammerObject()
        {
            List<HammerObject> entityList = new List<HammerObject>();

            BlockTexture texture = new BlockTexture
            {
                TopTexture = "tools/toolstrigger",
                DefaultTexture = "tools/toolstrigger"
            };
            Solid s = new Solid(X, Y, Z, Width, Breadth, Height, texture); //TODO
            s.AddRotationTask(Rotations);
            TriggerTeleport tp = new TriggerTeleport
            {
                X = X,
                Y = Y,
                Z = Z,
                Solid = s,
                Width = Width,
                Breadth = Breadth,
                Height = Height,
                Target = Target,
                Editor = Editor.GetDefault()
            };

            tp.AddRotationTask(Rotations);

            entityList.Add(tp);

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
