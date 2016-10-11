using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Structures
{
    public abstract class BhopChallenge
    {
        public Block Start { get; set; }
        public Teleport FailTeleport { get; set; }
        public int Difficulty { get; set; }
    }
}
