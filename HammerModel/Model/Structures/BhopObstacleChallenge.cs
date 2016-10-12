using HammerModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Structures
{
    public class BhopObstacleChallenge : BhopChallenge
    {
        public override List<HammerObject> ToHammerObject()
        {
            List<HammerObject> entityList = base.ToHammerObject();

            for (int i = X + Start.Width + 128; i < X + Width - End.Width; i += 128)
            {
                if(i%3 == 0)
                {
                    Block blockBlock = new Block
                    {
                        X = i,
                        Y = Y + HONHelper.GetRandomNumber(-128, 128) + (Breadth / 2) - StandardValues.BHOP_BLOCK_HEIGHT,
                        Z = Z + StandardValues.CHALLENGE_FAIL_HEIGHT,
                        Width = StandardValues.BHOP_BLOCK_WIDTH,
                        Breadth = StandardValues.BHOP_BLOCK_WIDTH,
                        Height = StandardValues.BHOP_OBSTACLE_HEIGHT,
                        Texture = TexturePack.AlternativeTexture
                    };
                    entityList.AddRange(blockBlock.ToHammerObject());
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
