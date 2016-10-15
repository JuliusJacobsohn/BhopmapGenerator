using HammerModel.Helpers;
using HammerModel.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Structures
{
    public abstract class BhopChallenge : TextureObject
    {
        public int ChallengeID { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Width { get; set; }
        public double Breadth { get; set; }
        public double Height { get; set; }
        protected Block Start { get; set; }
        protected Block End { get; set; }
        protected Teleport FailTeleport { get; set; }
        protected TeleportDestination FailTeleportDestination { get; set; }
        public double Difficulty { get; set; }

        public override List<HammerObject> ToHammerObject()
        {
            List<HammerObject> entityList = new List<HammerObject>();
            Start = new Block
            {
                X = X ,
                Y = Y,
                Z = Z,
                Width = StandardValues.CHALLENGE_START_WIDTH,
                Breadth = Breadth,
                Height = StandardValues.CHALLENGE_HEIGHT,
                Texture = TexturePack.FloorTexture
            };
            entityList.AddRange(Start.ToHammerObject());
            End = new Block
            {
                X = X + Width - Start.Width,
                Y = Y,
                Z = Z,
                Width = StandardValues.CHALLENGE_START_WIDTH,
                Breadth = Breadth,
                Height = StandardValues.CHALLENGE_HEIGHT,
                Texture = TexturePack.FloorTexture
            };
            entityList.AddRange(End.ToHammerObject());
            FailTeleport = new Teleport
            {
                X = X + Start.Width,
                Y = Y,
                Z = Z,
                Width = Width - (Start.Width + End.Width),
                Breadth = Breadth,
                Height = Height - StandardValues.CHALLENGE_FAIL_HEIGHT,
                Target = HONHelper.GetTeleportName(ChallengeID)
            };
            entityList.AddRange(FailTeleport.ToHammerObject());
            var tpDest = Start.GetSpawnCoordinates();
            FailTeleportDestination = new TeleportDestination
            {
                Name = HONHelper.GetTeleportName(ChallengeID),
                X = tpDest.X,
                Y = tpDest.Y,
                Z = tpDest.Z
            };
            entityList.AddRange(FailTeleportDestination.ToHammerObject());

            return entityList;
        }
    }
}
