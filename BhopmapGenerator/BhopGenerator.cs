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
            BhopRoom r = new BhopRoom(0, 0, 0, 4096 * 4, 512, 512, TexturePack);

            BhopSimpleChallenge c11 = new BhopSimpleChallenge
            {
                ChallengeID = HONHelper.GetUniqueId(),
                Difficulty = 1,
                TexturePack = TexturePack
            };
            BhopSimpleChallenge c12 = new BhopSimpleChallenge
            {
                ChallengeID = HONHelper.GetUniqueId(),
                Difficulty = 1,
                TexturePack = TexturePack
            };
            BhopSimpleChallenge c13 = new BhopSimpleChallenge
            {
                ChallengeID = HONHelper.GetUniqueId(),
                Difficulty = 1,
                TexturePack = TexturePack
            };
            BhopSimpleChallenge c14 = new BhopSimpleChallenge
            {
                ChallengeID = HONHelper.GetUniqueId(),
                Difficulty = 1,
                TexturePack = TexturePack
            };
            BhopObstacleChallenge c21 = new BhopObstacleChallenge
            {
                ChallengeID = HONHelper.GetUniqueId(),
                Difficulty = 1,
                TexturePack = TexturePack
            };
            BhopObstacleChallenge c22 = new BhopObstacleChallenge
            {
                ChallengeID = HONHelper.GetUniqueId(),
                Difficulty = 1,
                TexturePack = TexturePack
            };
            BhopObstacleChallenge c23 = new BhopObstacleChallenge
            {
                ChallengeID = HONHelper.GetUniqueId(),
                Difficulty = 1,
                TexturePack = TexturePack
            };
            BhopObstacleChallenge c24 = new BhopObstacleChallenge
            {
                ChallengeID = HONHelper.GetUniqueId(),
                Difficulty = 1,
                TexturePack = TexturePack
            };
            BhopFrameChallenge c31 = new BhopFrameChallenge
            {
                ChallengeID = HONHelper.GetUniqueId(),
                Difficulty = 1,
                TexturePack = TexturePack
            };
            BhopFrameChallenge c32 = new BhopFrameChallenge
            {
                ChallengeID = HONHelper.GetUniqueId(),
                Difficulty = 1,
                TexturePack = TexturePack
            };
            BhopFrameChallenge c33 = new BhopFrameChallenge
            {
                ChallengeID = HONHelper.GetUniqueId(),
                Difficulty = 1,
                TexturePack = TexturePack
            };
            BhopFrameChallenge c34 = new BhopFrameChallenge
            {
                ChallengeID = HONHelper.GetUniqueId(),
                Difficulty = 1,
                TexturePack = TexturePack
            };
            r.AddChallenge(c11, 0.05);
            r.AddChallenge(c12, 0.05);
            r.AddChallenge(c13, 0.07);
            r.AddChallenge(c14, 0.08);
            r.AddChallenge(c21, 0.05);
            r.AddChallenge(c22, 0.05);
            r.AddChallenge(c23, 0.07);
            r.AddChallenge(c24, 0.08);
            r.AddChallenge(c31, 0.05);
            r.AddChallenge(c32, 0.05);
            r.AddChallenge(c33, 0.07);
            r.AddChallenge(c34, 0.08);

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
