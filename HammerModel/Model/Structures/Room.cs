using HammerModel.Helpers;

using HammerModel.Model.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HammerModel.Model.Units;

namespace HammerModel.Model.Structures
{
    public abstract class Room : TextureObject, ISpawnable, IEndable
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Width { get; set; }
        public double Breadth { get; set; }
        public double Height { get; set; }

        /// <summary>
        /// Protected ctor to let child classes choose wether they can be initialized with an instanciator or not
        /// </summary>
        protected Room()
        {

        }

        public override List<HammerObject> ToHammerObject()
        {
            List<HammerObject> objectList = new List<HammerObject>();
            Block floor = new Block
            {
                X = X,
                Y = Y,
                Z = Z,
                Width = Width,
                Breadth = Breadth,
                Height = StandardValues.WALL_SIZE,
                Texture = TexturePack.FloorTexture
            };
            Block ceiling = new Block
            {
                X = X,
                Y = Y,
                Z = Z + Height - StandardValues.WALL_SIZE,
                Width = Width,
                Breadth = Breadth,
                Height = StandardValues.WALL_SIZE,
                Texture = TexturePack.CeilingTexture
            };
            Wall backWall = new Wall
            {
                X = X,
                Y = Y,
                Z = Z + StandardValues.WALL_SIZE,
                Width = Width,
                Breadth = StandardValues.WALL_SIZE,
                Height = Height - StandardValues.WALL_SIZE * 2,
                BottomPercentage = StandardValues.BOTTOM_PERECENTAGE,
                TexturePack = TexturePack
            };
            Wall frontWall = new Wall
            {
                X = X,
                Y = Y + Breadth - StandardValues.WALL_SIZE,
                Z = Z + StandardValues.WALL_SIZE,
                Width = Width,
                Breadth = StandardValues.WALL_SIZE,
                Height = Height - StandardValues.WALL_SIZE * 2,
                BottomPercentage = StandardValues.BOTTOM_PERECENTAGE,
                TexturePack = TexturePack
            };
            Wall rightWall = new Wall
            {
                X = X,
                Y = Y + StandardValues.WALL_SIZE,
                Z = Z + StandardValues.WALL_SIZE,
                Width = StandardValues.WALL_SIZE,
                Breadth = Breadth - StandardValues.WALL_SIZE * 2,
                Height = Height - StandardValues.WALL_SIZE * 2,
                BottomPercentage = StandardValues.BOTTOM_PERECENTAGE,
                TexturePack = TexturePack
            };
            Wall leftWall = new Wall
            {
                X = X + Width - StandardValues.WALL_SIZE,
                Y = Y + StandardValues.WALL_SIZE,
                Z = Z + StandardValues.WALL_SIZE,
                Width = StandardValues.WALL_SIZE,
                Breadth = Breadth - StandardValues.WALL_SIZE * 2,
                Height = Height - StandardValues.WALL_SIZE * 2,
                BottomPercentage = StandardValues.BOTTOM_PERECENTAGE,
                TexturePack = TexturePack
            };

            return HONHelper.ToHammerObject(Rotations,
                floor,
                ceiling,
                backWall,
                frontWall,
                rightWall,
                leftWall);
        }

        public override ValueTriple GetOrigin()
        {
            return new ValueTriple
            {
                X = X + Width / 2,
                Y = Y + Breadth / 2,
                Z = Z + Height / 2
            };
        }

        public ValueTriple GetSpawnCoordinates()
        {
            Block floor = new Block
            {
                X = X,
                Y = Y,
                Z = Z,
                Width = Width,
                Breadth = Breadth,
                Height = StandardValues.WALL_SIZE,
                Texture = TexturePack.FloorTexture
            };
            return floor.GetSpawnCoordinates();
        }

        public virtual ValueTriple GetEndCoordinates(Portal portal)
        {
            Block floor = new Block
            {
                X = X,
                Y = Y,
                Z = Z,
                Width = Width,
                Breadth = Breadth,
                Height = StandardValues.WALL_SIZE,
                Texture = TexturePack.FloorTexture
            };
            return floor.GetEndCoordinates(portal);
        }
    }
}
