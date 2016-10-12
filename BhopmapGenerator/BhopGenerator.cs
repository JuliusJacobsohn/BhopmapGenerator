using HammerModel.Helpers;
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
                Width = 2048,
                Breadth = 512,
                Height = 512,
                TexturePack = TexturePack
            };
            m.AddWorldObject(r);

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
            m.AddWorldObject(r2);

            BhopSimple c1 = new BhopSimple
            {
                X = StandardValues.WALL_SIZE,
                Y = StandardValues.WALL_SIZE,
                Z = StandardValues.WALL_SIZE,
                Width = r.Width - StandardValues.WALL_SIZE * 2,
                Breadth = r.Breadth - StandardValues.WALL_SIZE * 2,
                Height = StandardValues.CHALLENGE_HEIGHT,
                ChallengeID = HONHelper.GetUniqueId(),
                Difficulty = 1,
                TexturePack = TexturePack
            };
            m.AddWorldObject(c1);

            Spawn t = new Spawn
            {
                Terrorist = true,
                X = 110,
                Y = 110,
                Z = 110
            };
            m.AddWorldObject(t);

            Spawn ct = new Spawn
            {
                Terrorist = false,
                X = 110,
                Y = 180,
                Z = 110
            };
            m.AddWorldObject(ct);

            Console.WriteLine(m.ToString());
            File.WriteAllText(@"F:\Program Files (x86)\Steam\steamapps\common\Counter-Strike Global Offensive\sdk_content\maps\generated.vmf", m.ToString());
        }
    }
}
