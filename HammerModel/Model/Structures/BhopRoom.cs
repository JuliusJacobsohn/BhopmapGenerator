using HammerModel.Helpers;
using HammerModel.Model.Textures;
using HammerModel.Model.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Structures
{
    public class BhopRoom : Room
    {
        private Block Start;
        private Block End;
        private List<BhopChallenge> Challenges;
        public BhopRoom(int x, int y, int z, int width, int breadth, int height, TexturePack texturePack) : base()
        {
            X = x;
            Y = y;
            Z = z;
            Width = width;
            Breadth = breadth;
            Height = Height;
            TexturePack = texturePack;
            Start = new Block
            {
                X = x + StandardValues.WALL_SIZE,
                Y = y + StandardValues.WALL_SIZE,
                Z = z + StandardValues.WALL_SIZE,
                Width = 256,
                Breadth = breadth-StandardValues.WALL_SIZE*2,
                Height = 64,
                Texture = texturePack.StandardTexture
            };
        }

        public IntTriple GetStartLocation()
        {
            int x = Start.X + Start.Width / 2 - StandardValues.PLAYER_ENTITY_SIZE / 2;
            int y = Start.Y + Start.Breadth / 2 - StandardValues.PLAYER_ENTITY_SIZE / 2;
            int z = Start.Z;
            return new IntTriple
            {
                X = x,
                Y = y,
                Z = z
            };
        }
    }
}
