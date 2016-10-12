using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Textures
{
    public class TexturePack
    {
        public BlockTexture StandardTexture { get; set; }
        public WallTexture WallTexture { get; set; }
        public BlockTexture FloorTexture { get; set; }
        public BlockTexture CeilingTexture { get; set; }
        public static TexturePack GetDefault()
        {
            string orange = "dev/dev_measuregeneric01";
            string lightGray = "dev/graygrid";
            string darkGray = "dev/dev_measuregeneric01b";
            string sky = "tools/toolsskybox";

            return new TexturePack
            {
                FloorTexture = new BlockTexture
                {
                    DefaultTexture = darkGray,
                    TopTexture = darkGray
                },
                CeilingTexture = new BlockTexture
                {
                    DefaultTexture = sky,
                    TopTexture = sky
                },
                StandardTexture = new BlockTexture
                {
                    DefaultTexture = orange,
                    TopTexture = orange
                },
                WallTexture = new WallTexture
                {
                    Bottom = new BlockTexture
                    {
                        DefaultTexture = orange,
                        TopTexture = orange
                    },
                    Top = new BlockTexture
                {
                        DefaultTexture = darkGray,
                        TopTexture = darkGray
                    },
                }
            };
        }
    }
}
