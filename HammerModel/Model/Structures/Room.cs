using HammerModel.Helpers;

using HammerModel.Model.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Structures
{
    public abstract class Room : TextureObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int Width { get; set; }
        public int Breadth { get; set; }
        public int Height { get; set; }

        /// <summary>
        /// Protected ctor to let child classes choose wether they can be initialized with an instanciator or not
        /// </summary>
        protected Room()
        {

        }

        public override List<Solid> ToWorldObject()
        {
            List<Solid> roomList = new List<Solid>();
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
            roomList.AddRange(floor.ToWorldObject());
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
            roomList.AddRange(ceiling.ToWorldObject());
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
            roomList.AddRange(backWall.ToWorldObject());
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
            roomList.AddRange(frontWall.ToWorldObject());
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
            roomList.AddRange(rightWall.ToWorldObject());
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
            roomList.AddRange(leftWall.ToWorldObject());

            return roomList;
        }
    }
}
