using HammerModel.Model.Structures;
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
            entityList.Add(ips);

            return entityList;
        }
    }
}
