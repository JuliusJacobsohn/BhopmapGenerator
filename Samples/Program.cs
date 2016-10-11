using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HammerModel.Model;
using HammerModel.Model.Structures;
using HammerModel.Model.Misc;

namespace Samples
{
    class Program
    {
        static TextureInfo Orange = new TextureInfo
        {
            TopTexture = "dev/dev_measuregeneric01",
            SideTexture = "dev/dev_measuregeneric01"
        };
        static TextureInfo LightGray = new TextureInfo
        {
            TopTexture = "dev/graygrid",
            SideTexture = "dev/graygrid"
        };
        static TextureInfo DarkGray = new TextureInfo
        {
            TopTexture = "dev/dev_measuregeneric01b",
            SideTexture = "dev/dev_measuregeneric01b"
        };

        static void Main(string[] args)
        {
            //Creating a simple Map
            Map m = new Map();

            //Create a room and add it to the map
            Room room = new Room
            {
                X = 0,
                Y = 0,
                Z = 0,
                Width = 1024,
                Breadth = 512,
                Height = 384,
                CeilingTextureInfo = LightGray,
                FloorTextureInfo = DarkGray,
                WallTextureInfo = Orange
            };
            m.AddWorldObject(room);

            //Create spawns and add them to the Map
            for (int i = 0; i < 5; i++)
            {
                Spawn t = new Spawn
                {
                    Terrorist = true,
                    X = 50,
                    Y = 50 + i * 100,
                    Z = 10
                };
                Spawn ct = new Spawn
                {
                    Terrorist = false,
                    X = 950,
                    Y = 50 + i * 100,
                    Z = 10
                };
                m.AddEntity(t);
                m.AddEntity(ct);
            }

            //Create lights over the spawns
            for (int i = 0; i < 5; i++)
            {
                WorldLight tLight = new WorldLight
                {
                    X = 50,
                    Y = 50 + i * 100,
                    Z = 256
                };
                WorldLight ctLight = new WorldLight
                {
                    X = 950,
                    Y = 50 + i * 100,
                    Z = 256
                };
                m.AddEntity(tLight);
                m.AddEntity(ctLight);
            }

            //Create blocks to protect the spawn area and fill the map
            Wall tBlock = new Wall
            {
                X = 100,
                Y = 8, //WALL_WIDTH
                Z = 8,
                Width = 16,
                Breadth = 450,
                Height = 80,
                BottomPercentage = 0.7,
                BottomTexture = Orange,
                TopTexture = DarkGray
            };
            Wall ctBlock = new Wall
            {
                X = 900,
                Y = 8, //WALL_WIDTH
                Z = 8,
                Width = 16,
                Breadth = 450,
                Height = 80,
                BottomPercentage = 0.7,
                BottomTexture = Orange,
                TopTexture = DarkGray
            };
            m.AddWorldObject(tBlock);
            m.AddWorldObject(ctBlock);

            string mapString = m.ToString();

            Console.WriteLine(mapString);
            File.WriteAllText(@"F:\Program Files (x86)\Steam\steamapps\common\Counter-Strike Global Offensive\sdk_content\maps\sample.vmf", mapString);
        }
    }
}
