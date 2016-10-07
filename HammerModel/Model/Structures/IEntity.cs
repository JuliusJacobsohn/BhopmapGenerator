using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Structures
{
    public interface IEntity
    {
        int Id { get; set; }
        List<Entity> ToEntity();
    }
}
