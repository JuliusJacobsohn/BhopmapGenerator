using HammerModel.Model.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Entities
{
    public class WorldLight : HammerObject, IWorldEntity
    {
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
        public int A { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public List<Entity> ToWorldEntity()
        {
            List<Entity> entityList = new List<Entity>();

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
