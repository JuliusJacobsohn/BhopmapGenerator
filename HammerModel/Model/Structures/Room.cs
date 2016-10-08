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
        public const int WALL_SIZE = 8;
        public const double BOTTOM_PERECENTAGE = 0.8;
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int Width { get; set; }
        public int Breadth { get; set; }
        public int Height { get; set; }
        public TextureInfo WallTextureInfo { get; set; }
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
                Height = WALL_SIZE,
                TextureInfo = FloorTextureInfo
            };
            roomList.AddRange(floor.ToWorldObject());
            Block ceiling = new Block
            {
                X = X,
                Y = Y,
                Z = Z + Height - WALL_SIZE,
                Width = Width,
                Breadth = Breadth,
                Height = WALL_SIZE,
                TextureInfo = CeilingTextureInfo
            };
            roomList.AddRange(ceiling.ToWorldObject());
            Wall backWall = new Wall
            {
                X = X,
                Y = Y,
                Z = Z + WALL_SIZE,
                Width = Width,
                Breadth = WALL_SIZE,
                Height = Height - WALL_SIZE * 2,
                BottomPercentage = BOTTOM_PERECENTAGE,
                BottomTexture = WallTextureInfo,
                TopTexture = TextureInfo.GetDefault()
            };
            roomList.AddRange(backWall.ToWorldObject());
            Wall frontWall = new Wall
            {
                X = X,
                Y = Y + Breadth - WALL_SIZE,
                Z = Z + WALL_SIZE,
                Width = Width,
                Breadth = WALL_SIZE,
                Height = Height - WALL_SIZE * 2,
                BottomPercentage = BOTTOM_PERECENTAGE,
                BottomTexture = WallTextureInfo,
                TopTexture = TextureInfo.GetDefault()
            };
            roomList.AddRange(frontWall.ToWorldObject());
            Wall rightWall = new Wall
            {
                X = X,
                Y = Y + WALL_SIZE,
                Z = Z + WALL_SIZE,
                Width = WALL_SIZE,
                Breadth = Breadth - WALL_SIZE * 2,
                Height = Height - WALL_SIZE * 2,
                BottomPercentage = BOTTOM_PERECENTAGE,
                BottomTexture = WallTextureInfo,
                TopTexture = TextureInfo.GetDefault()
            };
            roomList.AddRange(rightWall.ToWorldObject());
            Wall leftWall = new Wall
            {
                X = X + Width - WALL_SIZE,
                Y = Y + WALL_SIZE,
                Z = Z + WALL_SIZE,
                Width = WALL_SIZE,
                Breadth = Breadth - WALL_SIZE * 2,
                Height = Height - WALL_SIZE * 2,
                BottomPercentage = BOTTOM_PERECENTAGE,
                BottomTexture = WallTextureInfo,
                TopTexture = TextureInfo.GetDefault()
            };
            roomList.AddRange(leftWall.ToWorldObject());

            return roomList;
        }
    }
}
