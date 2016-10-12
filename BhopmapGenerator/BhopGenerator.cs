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
            BhopRoom r = new BhopRoom(0, 0, 0, 4096, 512, 512, TexturePack);

            BhopSimple c1 = new BhopSimple
            {
                ChallengeID = HONHelper.GetUniqueId(),
                Difficulty = 1,
                TexturePack = TexturePack
            };
            BhopSimple c2 = new BhopSimple
            {
                ChallengeID = HONHelper.GetUniqueId(),
                Difficulty = 1,
                TexturePack = TexturePack
            };
            BhopSimple c3 = new BhopSimple
            {
                ChallengeID = HONHelper.GetUniqueId(),
                Difficulty = 1,
                TexturePack = TexturePack
            };
            r.AddChallenge(c1, 0.2);
            r.AddChallenge(c2, 0.3);
            r.AddChallenge(c3, 0.5);

            m.AddWorldObject(r);

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
            File.WriteAllText(@"F:\Program Files (x86)\Steam\steamapps\common\Counter-Strike Global Offensive\sdk_content\maps\bhop_generated.vmf", m.ToString());
        }
    }
}
