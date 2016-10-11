using HammerModel.Model.Misc;
using HammerModel.Model.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Structures
{
    public class Room : IWorldObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int Width { get; set; }
        public int Breadth { get; set; }
        public int Height { get; set; }
        public WallTextureInfo WallTextureInfo { get; set; }
        public TextureInfo FloorTextureInfo { get; set; }
        public TextureInfo CeilingTextureInfo { get; set; }

        public List<Solid> ToWorldObject()
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
                TextureInfo = FloorTextureInfo
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
                TextureInfo = CeilingTextureInfo
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
                WallTexture = WallTextureInfo
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
                WallTexture = WallTextureInfo
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
                WallTexture = WallTextureInfo
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
                WallTexture = WallTextureInfo
            };
            roomList.AddRange(leftWall.ToWorldObject());

            return roomList;
        }
    }
}
