using HammerModel.Helpers;
using HammerModel.Model.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model
{
    public class InfoTeleportDestination : Entity
    {
        public override string ClassName
        {
            get
            {
                return "info_teleport_destination";
            }
        }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public ValueTriple Origin
        {
            get
            {
                ValueTriple v = new ValueTriple
                {
                    X = X,
                    Y = Y,
                    Z = Z
                };
                foreach(var task in Rotations)
                {
                    v = MatrixHelper.Rotate(v, task);
                }
                return v;
            }
        }
        public ValueTriple Angles = new ValueTriple { X = 0, Y = 0, Z = 0 }; //TODO: turn angles as well
        public string TargetName { get; set; }

        public override string ToString()
        {
            Editor = Editor.GetDefault();
            return HONHelper.GetHonObjectBody("entity",
                HONHelper.GetKeyValuePair("id", Id),
                HONHelper.GetKeyValuePair("classname", ClassName),
                HONHelper.GetKeyValuePair("angles", Angles),
                HONHelper.GetKeyValuePair("targetname", TargetName),
                HONHelper.GetKeyValuePair("origin", Origin),
                Editor.ToString());
        }
    }
}
