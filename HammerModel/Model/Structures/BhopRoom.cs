using HammerModel.Helpers;
using HammerModel.Model.Textures;
using HammerModel.Model.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Structures
{
    public class BhopRoom : Room
    {
        private Block Start;
        private Block End;
        private List<Tuple<BhopChallenge, double>> Challenges;
        public BhopRoom(double x, double y, double z, double width, double breadth, double height, TexturePack texturePack) : base()
        {
            Challenges = new List<Tuple<BhopChallenge, double>>();
            X = x;
            Y = y;
            Z = z;
            Width = width;
            Breadth = breadth;
            Height = height;

            TexturePack = texturePack;
            Start = new Block
            {
                X = x + StandardValues.WALL_SIZE,
                Y = y + StandardValues.WALL_SIZE,
                Z = z + StandardValues.WALL_SIZE,
                Width = 256,
                Breadth = breadth - StandardValues.WALL_SIZE * 2,
                Height = 64,
                Texture = texturePack.StandardTexture
            };
        }

        public void AddChallenge(BhopChallenge challenge, double percentageOfRoom)
        {
            Challenges.Add(new Tuple<BhopChallenge, double>(challenge, percentageOfRoom));
        }

        public ValueTriple GetStartLocation()
        {
            double x = Start.X + Start.Width / 2 - StandardValues.PLAYER_ENTITY_SIZE / 2;
            double y = Start.Y + Start.Breadth / 2 - StandardValues.PLAYER_ENTITY_SIZE / 2;
            double z = Start.Z;
            return new ValueTriple
            {
                X = x,
                Y = y,
                Z = z
            };
        }

        public override List<HammerObject> ToHammerObject()
        {
            List<HammerObject> objectList = base.ToHammerObject();


            Start = new Block
            {
                X = X + StandardValues.WALL_SIZE,
                Y = Y + StandardValues.WALL_SIZE,
                Z = Z + StandardValues.WALL_SIZE,
                Width = StandardValues.CHALLENGE_START_WIDTH,
                Breadth = Breadth - (StandardValues.WALL_SIZE * 2),
                Height = StandardValues.CHALLENGE_HEIGHT,
                Texture = TexturePack.FloorTexture
            };

            double oldX = Start.Width;

            double dWidth = Width - (StandardValues.WALL_SIZE * 2) - (StandardValues.CHALLENGE_START_WIDTH * 2);
            double tWidth = 0;

            foreach (var tuple in Challenges)
            {
                var challenge = tuple.Item1;
                var percentage = tuple.Item2;

                challenge.X = X + oldX + StandardValues.WALL_SIZE;
                challenge.Y = Y + StandardValues.WALL_SIZE;
                challenge.Z = Z + StandardValues.WALL_SIZE;
                challenge.Width = (int)((Width - StandardValues.CHALLENGE_START_WIDTH * 2 - StandardValues.WALL_SIZE * 2) * percentage);
                challenge.Breadth = Breadth - (StandardValues.WALL_SIZE * 2);
                challenge.Height = StandardValues.CHALLENGE_HEIGHT;


                oldX = oldX + challenge.Width;
                tWidth = tWidth + challenge.Width;
                if (challenge == Challenges.Last().Item1 && dWidth - tWidth != 0)
                {
                    challenge.Width = challenge.Width + (dWidth - tWidth);
                }

                challenge.AddRotationTask(Rotations);
                objectList.AddRange(challenge.ToHammerObject());
            }


            End = new Block
            {
                X = X + Width - (StandardValues.CHALLENGE_START_WIDTH + StandardValues.WALL_SIZE),
                Y = Y + StandardValues.WALL_SIZE,
                Z = Z + StandardValues.WALL_SIZE,
                Width = StandardValues.CHALLENGE_START_WIDTH,
                Breadth = Breadth - (StandardValues.WALL_SIZE * 2),
                Height = StandardValues.CHALLENGE_HEIGHT,
                Texture = TexturePack.FloorTexture
            };

            Start.AddRotationTask(Rotations);
            End.AddRotationTask(Rotations);

            objectList.AddRange(Start.ToHammerObject());
            objectList.AddRange(End.ToHammerObject());

            return objectList;
        }

        public override ValueTriple GetEndCoordinates(Portal portal)
        {
            throw new NotImplementedException();
        }
    }
}
