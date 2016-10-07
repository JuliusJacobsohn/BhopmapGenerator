using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model
{
    public interface IDefaultable<T>
    {
        T GetDefault();
    }
}
