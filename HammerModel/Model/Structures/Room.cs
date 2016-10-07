using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BhopmapGenerator.Model.Structures
{
    public class Room : IWorldObject
    {
        public const int WALL_SIZE = 8;
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Width { get; set; }
        public double Breadth { get; set; }
        public double Height { get; set; }
        public TextureInfo WallTextureInfo { get; set; }
        public TextureInfo FloorTextureInfo { get; set; }
        public TextureInfo CeilingTextureInfo { get; set; }

        public List<Solid> ToWorldObject()
        {
            List<Solid> roomList = new List<Solid>();
            Cuboid floor = new Cuboid
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
            Cuboid ceiling = new Cuboid
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
            Cuboid backWall = new Cuboid
            {
                X = X,
                Y = Y,
                Z = Z + WALL_SIZE,
                Width = Width,
                Breadth = WALL_SIZE,
                Height = Height - WALL_SIZE * 2,
                TextureInfo = WallTextureInfo
            };
            roomList.AddRange(backWall.ToWorldObject());
            Cuboid frontWall = new Cuboid
            {
                X = X,
                Y = Y + Breadth - WALL_SIZE,
                Z = Z + WALL_SIZE,
                Width = Width,
                Breadth = WALL_SIZE,
                Height = Height - WALL_SIZE * 2,
                TextureInfo = WallTextureInfo
            };
            roomList.AddRange(frontWall.ToWorldObject());
            Cuboid rightWall = new Cuboid
            {
                X = X,
                Y = Y + WALL_SIZE,
                Z = Z + WALL_SIZE,
                Width = WALL_SIZE,
                Breadth = Breadth - WALL_SIZE * 2,
                Height = Height - WALL_SIZE * 2,
                TextureInfo = WallTextureInfo
            };
            roomList.AddRange(rightWall.ToWorldObject());
            Cuboid leftWall = new Cuboid
            {
                X = X + Width - WALL_SIZE,
                Y = Y + WALL_SIZE,
                Z = Z + WALL_SIZE,
                Width = WALL_SIZE,
                Breadth = Breadth - WALL_SIZE * 2,
                Height = Height - WALL_SIZE * 2,
                TextureInfo = WallTextureInfo
            };
            roomList.AddRange(leftWall.ToWorldObject());

            return roomList;
        }
    }
}
