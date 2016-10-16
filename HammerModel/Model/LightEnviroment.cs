using HammerModel.Model.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model
{
    public class LightEnviroment : Light
    {
        public override string ClassName
        {
            get
            {
                return "light_environment";
            }
        }
        public LightValue _Ambient { get; set; }
        public LightValue _AmbientHDR = LightValue.GetDefault();
        public int _AmbientScaleHDR = 1; //TODO: Is this really an int?
        public ValueTriple Angles = new ValueTriple { X = 0, Y = 0, Z = 0 };
    }
}
