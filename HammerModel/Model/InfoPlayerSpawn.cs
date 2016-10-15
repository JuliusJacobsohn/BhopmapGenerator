using HammerModel.Helpers;
using HammerModel.Model;
using HammerModel.Model.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model
{
    public class InfoPlayerSpawn : Entity
    {
        public bool Terrorist { get; set; }

        public override string ClassName
        {
            get
            {
                if (Terrorist)
                {
                    return "info_player_terrorist";
                }
                else
                {
                    return "info_player_counterterrorist";
                }
            }
        }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public ValueTriple Origin
        {
            get
            {
                return new ValueTriple
                {
                    X = X,
                    Y = Y,
                    Z = Z
                };
            }
        }

        public ValueTriple Angles = new ValueTriple { X = 0, Y = 0, Z = 0 };
        public int Enabled = 1;
        public override string ToString()
        {
            Editor = Editor.GetDefault();
            return HONHelper.GetHonObjectBody("entity",
                HONHelper.GetKeyValuePair("id", Id),
                HONHelper.GetKeyValuePair("classname", ClassName),
                HONHelper.GetKeyValuePair("angles", Angles),
                HONHelper.GetKeyValuePair("enabled", Enabled),
                HONHelper.GetKeyValuePair("origin", Origin),
                Editor.ToString());
        }
    }
}
