using HammerModel.Helpers;
using HammerModel.Model.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model
{
    public class TriggerTeleport : Entity
    {
        public override string ClassName
        {
            get
            {
                return "trigger_teleport";
            }
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int Width { get; set; }
        public int Breadth { get; set; }
        public int Height { get; set; }
        public IntTriple Origin
        {
            get
            {
                return new IntTriple
                {
                    X = X + (Width / 2),
                    Y = Y + (Breadth / 2),
                    Z = Z + (Height / 2)
                };
            }
        }
        public Solid Solid { get; set; }
        public int CheckDestIfClearForPlayer = 0;
        public int SpawnFlags = 4097;
        public int StartDisabled = 0;
        public string Target { get; set; }
        public int UseLandmarkAngles = 0;

        public override string ToString()
        {
            Editor = Editor.GetDefault();
            return HONHelper.GetHonObjectBody("entity",
                HONHelper.GetKeyValuePair("id", Id),
                HONHelper.GetKeyValuePair("classname", ClassName),
                HONHelper.GetKeyValuePair("CheckDestIfClearForPlayer", CheckDestIfClearForPlayer),
                HONHelper.GetKeyValuePair("origin", Origin),
                HONHelper.GetKeyValuePair("spawnflags", SpawnFlags),
                HONHelper.GetKeyValuePair("StartDisabled", StartDisabled),
                HONHelper.GetKeyValuePair("target", Target),
                HONHelper.GetKeyValuePair("UseLandmarkAngles", UseLandmarkAngles),
                Solid.ToString(),
                Editor.ToString());
        }
    }
}
