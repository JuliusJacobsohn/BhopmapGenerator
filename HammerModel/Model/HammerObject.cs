using HammerModel.Model.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model
{
    public abstract class HammerObject
    {
        protected int Id
        {
            get
            {
                return HONHelper.GetUniqueId();
            }
        }
    }
}
