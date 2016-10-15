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
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Width { get; set; }
        public double Breadth { get; set; }
        public double Height { get; set; }
        public ValueTriple Origin
        {
            get
            {
                return new ValueTriple
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
