
using HammerModel.Model.Textures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HammerModel.Model.Units;
using HammerModel.Helpers;

namespace HammerModel.Model.Structures
{
    public class Block : WorldObject, ISpawnable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int Width { get; set; }
        public int Breadth { get; set; }
        public int Height { get; set; }
        public BlockTexture Texture { get; set; }

        public override List<HammerObject> ToHammerObject()
        {
            List<HammerObject> entityList = new List<HammerObject>();

            entityList.Add(new Solid(X, Y, Z, Width, Breadth, Height, Texture));

            return entityList;
        }

        public IntTriple GetSpawnCoordinates()
        {
            return new IntTriple
            {
                X = X + Width / 2 - StandardValues.PLAYER_ENTITY_SIZE / 2,
                Y = Y + Breadth / 2 - StandardValues.PLAYER_ENTITY_SIZE / 2,
                Z = Z + Height
            };
        }
    }
}
