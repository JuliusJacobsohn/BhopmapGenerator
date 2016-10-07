using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Structures
{
    public class Teleport : IEntity
    {

        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int Width { get; set; }
        public int Breadth { get; set; }
        public int Height { get; set; }
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
                Id = Id,
                Editor = Editor.GetDefault()
            };
            entityList.Add(tp);

            return entityList;
        }
    }
}
