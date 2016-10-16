using HammerModel.Helpers;
using HammerModel.Model.Entities;
using HammerModel.Model.Units;
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
            var tpDest = Start.GetSpawnCoordinates();
            FailTeleportDestination = new TeleportDestination
            {
                Name = HONHelper.GetTeleportName(ChallengeID),
                X = tpDest.X,
                Y = tpDest.Y,
                Z = tpDest.Z
            };

            Start.AddRotationTask(Rotations);
            End.AddRotationTask(Rotations);
            FailTeleport.AddRotationTask(Rotations);
            FailTeleportDestination.AddRotationTask(Rotations);

            entityList.AddRange(Start.ToHammerObject());
            entityList.AddRange(End.ToHammerObject());
            entityList.AddRange(FailTeleport.ToHammerObject());
            entityList.AddRange(FailTeleportDestination.ToHammerObject());

            return entityList;
        }

        public override ValueTriple GetOrigin()
        {
            return new ValueTriple
            {
                X = X + Width / 2,
                Y = Y + Breadth / 2,
                Z = Z + Height / 2
            };
        }
    }
}
