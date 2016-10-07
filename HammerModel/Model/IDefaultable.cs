using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BhopmapGenerator.Model
{
    public interface IDefaultable<T>
    {
        T GetDefault();
    }
}
