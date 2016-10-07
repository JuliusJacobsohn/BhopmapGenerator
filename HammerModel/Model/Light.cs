using HammerModel.Model.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model
{
    public class Light : Entity
    {
        public override string ClassName
        {
            get
            {
                return "light";
            }
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public IntTriple Origin
        {
            get
            {
                return new IntTriple
                {
                    X = X,
                    Y = Y,
                    Z = Z
                };
            }
        }
        public LightValue _Light { get; set; }
        public LightValue _LightHDR { get; set; }
        public int _LightScaleHDR = 1; //TODO: Is this really an int?
        public int _QuadraticAttn = 1; //TODO: Is this really an int?

        public override string ToString()
        {
            Editor = Editor.GetDefault();
            _LightHDR = LightValue.GetDefault();
            return HONHelper.GetHonObjectBody("entity",
                HONHelper.GetKeyValuePair("id", Id),
                HONHelper.GetKeyValuePair("classname", ClassName),
                HONHelper.GetKeyValuePair("_light", _Light),
                HONHelper.GetKeyValuePair("_lightHDR", _LightHDR),
                HONHelper.GetKeyValuePair("_lightscaleHDR", _LightScaleHDR),
                HONHelper.GetKeyValuePair("_quadratic_attn", _QuadraticAttn),
                HONHelper.GetKeyValuePair("origin", Origin),
                Editor.ToString());
        }
    }
}
