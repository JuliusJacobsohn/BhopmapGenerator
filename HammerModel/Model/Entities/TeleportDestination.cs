using HammerModel.Helpers;
using HammerModel.Model.Structures;
using HammerModel.Model.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Entities
{
    public class TeleportDestination : WorldObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public string Name { get; set; }

        public override List<HammerObject> ToHammerObject()
        {
            List<HammerObject> entityList = new List<HammerObject>();

            InfoTeleportDestination ips = new InfoTeleportDestination
            {
                X = X,
                Y = Y,
                Z = Z,
                TargetName = Name,
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
