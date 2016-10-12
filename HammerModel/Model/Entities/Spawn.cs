using HammerModel.Model.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HammerModel.Model;

namespace HammerModel.Model.Entities
{
    public class Spawn : WorldObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public bool Terrorist { get; set; }

        public override List<HammerObject> ToHammerObject()
        {
            List<HammerObject> entityList = new List<HammerObject>();

            InfoPlayerSpawn ips = new InfoPlayerSpawn
            {
                X = X,
                Y = Y,
                Z = Z,
                Terrorist = Terrorist,
                Editor = Editor.GetDefault()
            };
            entityList.Add(ips);

            return entityList;
        }
    }
}
