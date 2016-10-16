using HammerModel.Helpers;
using HammerModel.Model;
using HammerModel.Model.Entities;
using HammerModel.Model.Structures;
using HammerModel.Model.Textures;
using HammerModel.Model.Units;
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
            BhopRoom r = new BhopRoom(0, 0, 0, 4096 * 3, 512, 512, TexturePack);

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

            //m.AddWorldObject(r);

            Spawn t = new Spawn
            {
                Terrorist = true,
                X = 110,
                Y = 110,
                Z = 110
            };
            //m.AddWorldObject(t);

            Spawn ct = new Spawn
            {
                Terrorist = false,
                X = 110,
                Y = 180,
                Z = 110
            };
            //m.AddWorldObject(ct);

            //for (int i = 0; i < 10; i++)
            //{
            //    Block b = new Block
            //    {
            //        X = 256,
            //        Y = 256,
            //        Z = -128 + i * 256,
            //        Width = 256,
            //        Breadth = 256,
            //        Height = 256,
            //        Texture = TexturePack.StandardTexture
            //    };
            //    b.AddRotationTask(RotationType.Z, i*10, new ValueTriple { X = b.X + b.Width / 2, Y = b.Y + b.Breadth / 2, Z = b.Z + b.Height / 2 });
            //    m.AddWorldObject(b);
            //}

            BhopRoom room = new BhopRoom(0, 0, 0, 1028, 512, 512, TexturePack);
            BhopRoom room2 = new BhopRoom(1028, 0, 0, 1028, 512, 512, TexturePack);

            BhopSimpleChallenge challenge = new BhopSimpleChallenge
            {
                ChallengeID = HONHelper.GetUniqueId(),
                Difficulty = 1,
                TexturePack = TexturePack
            };

            room.AddChallenge(challenge, 1);
            room2.AddChallenge(challenge, 1);
            room2.AddRotationTask(RotationType.Z, 45, new ValueTriple { X = 1028, Y = 512, Z = 0 });

            m.AddWorldObject(room);
            m.AddWorldObject(room2);



            Console.WriteLine(m.ToString());
            File.WriteAllText(@"F:\Program Files (x86)\Steam\steamapps\common\Counter-Strike Global Offensive\sdk_content\maps\bhop_generated.vmf", m.ToString());
        }
    }
}
