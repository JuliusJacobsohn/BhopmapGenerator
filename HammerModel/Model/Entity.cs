using System.Collections.Generic;

namespace HammerModel.Model
{
    public abstract class Entity : HammerObject
    {
        public abstract string ClassName { get; }
        public Editor Editor { get; set; }
        public override abstract string ToString();
    }
}