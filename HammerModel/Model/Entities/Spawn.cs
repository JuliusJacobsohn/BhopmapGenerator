using HammerModel.Model.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HammerModel.Model;
using HammerModel.Model.Units;
using HammerModel.Helpers;

namespace HammerModel.Model.Entities
{
    public class Spawn : WorldObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
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

            ips.AddRotationTask(Rotations);

            entityList.Add(ips);

            return entityList;
        }

        public override ValueTriple GetOrigin()
        {
            return new ValueTriple
            {
                X = X + StandardValues.PLAYER_ENTITY_SIZE / 2,
                Y = Y + StandardValues.PLAYER_ENTITY_SIZE / 2,
                Z = Z
            };
        }
    }
}
