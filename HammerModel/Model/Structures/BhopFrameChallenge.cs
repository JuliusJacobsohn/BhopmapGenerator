using HammerModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Structures
{
    public class BhopFrameChallenge : BhopChallenge
    {
        public override List<HammerObject> ToHammerObject()
        {
            List<HammerObject> entityList = base.ToHammerObject();

            for (double i = X + Start.Width + 128; i < X + Width - End.Width; i += 128)
            {
                if (i % 3 == 0)
                {
                    Block rightFrame = new Block
                    {
                        X = i,
                        Y = Y,
                        Z = Z,
                        Width = StandardValues.WALL_SIZE,
                        Breadth = (Breadth / 2) - (int)(StandardValues.PLAYER_ENTITY_SIZE * 2.5),
                        Height = StandardValues.BHOP_OBSTACLE_HEIGHT,
                        Texture = TexturePack.AlternativeTexture
                    };
                    entityList.AddRange(rightFrame.ToHammerObject());
                    Block leftFrame = new Block
                    {
                        X = i,
                        Y = Y+Breadth-rightFrame.Breadth,
                        Z = Z,
                        Width = StandardValues.WALL_SIZE,
                        Breadth = (Breadth / 2) - (int)(StandardValues.PLAYER_ENTITY_SIZE * 2.5),
                        Height = StandardValues.BHOP_OBSTACLE_HEIGHT,
                        Texture = TexturePack.AlternativeTexture
                    };
                    entityList.AddRange(leftFrame.ToHammerObject());
                }
                else
                {
                    BhopBlock currentBlock = new BhopBlock
                    {
                        X = i,
                        Y = Y + HONHelper.GetRandomNumber(-128, 128) + (Breadth / 2) - StandardValues.BHOP_BLOCK_HEIGHT,
                        Z = Z + StandardValues.CHALLENGE_FAIL_HEIGHT,
                        Width = StandardValues.BHOP_BLOCK_WIDTH,
                        Breadth = StandardValues.BHOP_BLOCK_WIDTH,
                        Height = StandardValues.BHOP_BLOCK_HEIGHT,
                        Texture = TexturePack.StandardTexture
                    };
                    entityList.AddRange(currentBlock.ToHammerObject());
                }
            }

            return entityList;
        }
    }
}
