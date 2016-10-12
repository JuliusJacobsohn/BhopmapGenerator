
using HammerModel.Model.Textures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Entities
{
    public class Teleport : IWorldEntity
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int Width { get; set; }
        public int Breadth { get; set; }
        public int Height { get; set; }
        public string Target { get; set; }

        public List<Entity> ToWorldEntity()
        {
            List<Entity> entityList = new List<Entity>();

            BlockTexture texture = new BlockTexture
            {
                TopTexture = "tools/toolstrigger",
                DefaultTexture = "tools/toolstrigger"
            };
            TriggerTeleport tp = new TriggerTeleport
            {
                Solid = new Solid(X, Y, Z, Width, Breadth, Height, texture),
                X = X,
                Y = Y,
                Z = Z,
                Width = Width,
                Breadth = Breadth,
                Height = Height,
                Target = Target,
                Editor = Editor.GetDefault()
            };
            entityList.Add(tp);

            return entityList;
        }
    }
}
