using HammerModel.Model.Structures;
using HammerModel.Model.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Entities
{
    public class WorldLight : WorldObject
    {
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
        public int A { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public override List<HammerObject> ToHammerObject()
        {
            List<HammerObject> entityList = new List<HammerObject>();

            Light l = new Light
            {
                X = X,
                Y = Y,
                Z = Z,
                _Light = new LightValue
                {
                    R = R,
                    G = G,
                    B = B,
                    A = A
                },
                Editor = Editor.GetDefault()
            };
            entityList.Add(l);

            return entityList;
        }
    }
}
