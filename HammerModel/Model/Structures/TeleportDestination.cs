using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Structures
{
    public class TeleportDestination : IWorldEntity
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public string Name { get; set; }

        public List<Entity> ToWorldEntity()
        {
            List<Entity> entityList = new List<Entity>();

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
