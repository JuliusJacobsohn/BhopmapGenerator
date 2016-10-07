using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BhopmapGenerator.Model.Structures
{
    public class Teleport : IEntity
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Width { get; set; }
        public double Breadth { get; set; }
        public double Height { get; set; }
        public TextureInfo TextureInfo
        {
            get
            {
                return new TextureInfo
                {
                    TopTexture = "tools/toolstrigger",
                    SideTexture = "tools/toolstrigger"
                };
            }
        }
        public string Target { get; set; }

        public List<Entity> ToEntity()
        {
            List<Entity> entityList = new List<Entity>();

            TriggerTeleport tp = new TriggerTeleport
            {
                Solid = new Solid(X, Y, Z, Width, Breadth, Height, TextureInfo),
                Target = Target,
                Id = 0,
                Editor = Editor.GetDefault()
            };
            entityList.Add(tp);

            return entityList;
        }
    }
}
