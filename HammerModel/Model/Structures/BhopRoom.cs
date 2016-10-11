using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Structures
{
    public class BhopRoom : Room
    {
        public Block End { get; set; }
        public List<BhopChallenge> Challenges { get; set; }
    }
}
