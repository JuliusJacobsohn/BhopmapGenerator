
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
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Width { get; set; }
        public double Breadth { get; set; }
        public double Height { get; set; }
        public BlockTexture Texture { get; set; }

        public override List<HammerObject> ToHammerObject()
        {
            List<HammerObject> entityList = new List<HammerObject>();

            entityList.Add(new Solid(X, Y, Z, Width, Breadth, Height, Texture));

            return entityList;
        }

        public ValueTriple GetSpawnCoordinates()
        {
            return new ValueTriple
            {
                X = X + Width / 2 - StandardValues.PLAYER_ENTITY_SIZE / 2,
                Y = Y + Breadth / 2 - StandardValues.PLAYER_ENTITY_SIZE / 2,
                Z = Z + Height
            };
        }
    }
}
