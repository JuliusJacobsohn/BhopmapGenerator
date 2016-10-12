
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Structures
{
    public abstract class WorldObject
    {
        public abstract List<Solid> ToWorldObject();
    }
}
