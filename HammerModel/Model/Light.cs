using HammerModel.Helpers;
using HammerModel.Model.Units;
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
        public LightValue _Light { get; set; }
        public LightValue _LightHDR = LightValue.GetDefault();
        public int _LightScaleHDR = 1; //TODO: Is this really an int?
        public int _QuadraticAttn = 1; //TODO: Is this really an int?

        public override string ToString()
        {
            Editor = Editor.GetDefault();
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
