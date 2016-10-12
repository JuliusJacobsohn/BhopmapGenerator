using HammerModel.Model;
using HammerModel.Model.Entities;
using HammerModel.Model.Structures;
using HammerModel.Model.Textures;
using System;
using System.IO;

namespace BhopmapGenerator
{
    public class BhopGenerator
    {
        private TexturePack TexturePack = TexturePack.GetDefault();
        public BhopGenerator()
        {
            Map m = new Map();
            SimpleRoom r = new SimpleRoom
            {
                X = 0,
                Y = 0,
                Z = 0,
                Width = 1024,
                Breadth = 512,
                Height = 256,
                TexturePack = TexturePack
            };
            SimpleRoom r2 = new SimpleRoom
            {
                X = 0,
                Y = 512,
                Z = 0,
                Width = 4096,
                Breadth = 512,
                Height = 256,
                TexturePack = TexturePack
            };
            Teleport tp = new Teleport
            {
                X = 0,
                Y = 0,
                Z = 0,
                Width = 100,
                Breadth = 100,
                Height = 100,
                Target = "test_dest_1"
            };
            TeleportDestination td = new TeleportDestination
            {
                Name = "test_dest_1",
                X = 128,
                Y = 712,
                Z = 20
            };

            Spawn t = new Spawn
            {
                Terrorist = true,
                X = 110,
                Y = 110,
                Z = 110
            };
            Spawn ct = new Spawn
            {
                Terrorist = false,
                X = 110,
                Y = 180,
                Z = 110
            };

            for (int i = 0; i < 10; i++)
            {
                WorldLight l = new WorldLight
                {
                    X = 110 + i * 100,
                    Y = 110,
                    Z = 230,
                    R = 255,
                    G = 255,
                    B = 255,
                    A = 200,
                };
                m.AddWorldEntity(l);
            }

            m.AddWorldEntity(t);
            m.AddWorldEntity(ct);
            m.AddWorldObject(r);
            m.AddWorldObject(r2);
            m.AddWorldEntity(tp);
            m.AddWorldEntity(td);

            //for(int i = 0; i < 50; i++)
            //{
            //    Cuboid c = new Cuboid
            //    {
            //        X = i * 32,
            //        Y = i * 32,
            //        Z = i * 32,
            //        Width = i * 32,
            //        Breadth = i * 32,
            //        Height = i * 32
            //    };
            //    m.AddWorldObject(c); //TODO: Fehler mit der ID herausfinden
            //}

            Console.WriteLine(m.ToString());
            File.WriteAllText(@"F:\Program Files (x86)\Steam\steamapps\common\Counter-Strike Global Offensive\sdk_content\maps\generated.vmf", m.ToString());
        }
    }
}
