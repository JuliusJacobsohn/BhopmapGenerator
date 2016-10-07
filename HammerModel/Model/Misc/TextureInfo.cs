using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Misc
{
    public class TextureInfo
    {
        public string TopTexture { get; set; }
        public string SideTexture { get; set; }

        public static TextureInfo GetDefault()
        {
            return new TextureInfo
            {
                TopTexture = "ADS/AD01",
                SideTexture = "ADS/AD01"
            };
        }
    }
}
