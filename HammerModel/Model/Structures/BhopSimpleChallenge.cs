using HammerModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Structures
{
    public class BhopSimpleChallenge : BhopChallenge
    {
        public override List<HammerObject> ToHammerObject()
        {
            List<HammerObject> entityList = base.ToHammerObject();

            for (double i = X + Start.Width + 128; i < X + Width - End.Width - 128; i += 128)
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

                currentBlock.AddRotationTask(Rotations);

                entityList.AddRange(currentBlock.ToHammerObject());
            }

            return entityList;
        }
    }
}
