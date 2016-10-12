using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Textures
{
    public class BlockTexture
    {
        public string TopTexture { get; set; }
        public string DefaultTexture { get; set; }

        public static BlockTexture GetDefault()
        {
            return new BlockTexture
            {
                TopTexture = "ADS/AD01",
                DefaultTexture = "ADS/AD01"
            };
        }
    }
}
