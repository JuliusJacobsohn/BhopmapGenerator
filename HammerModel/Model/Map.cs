using HammerModel.Model.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model
{
    public class Map
    {
        public Map()
        {
            World = new World
            {
                MapVersion = 1,
                ClassName = "worldspawn",
                DetailMaterial = "detail/detailsprites",
                DetailVbsp = "detail.vbsp",
                MaxPropScreenWidth = -1,
                SkyName = "sky_dust",
                Solids = new List<Solid>(),
                Groups = new List<Editor>()
            };
            Entities = new List<Entity>();
        }
        public World World { get; set; }
        public List<Entity> Entities { get; set; }
        public override string ToString()
        {
            string entityString = "";
            foreach (Entity entity in Entities)
            {
                entityString = entityString + entity.ToString() + "\n";
            }

            return World.ToString() + "\n" +
                entityString;
        }

        public void AddWorldObject(IWorldObject o)
        {
            World.Solids.AddRange(o.ToWorldObject());
            //World.Groups.AddRange(o.) TODO
        }

        public void AddEntity(IWorldEntity e)
        {
            Entities.AddRange(e.ToWorldEntity());
        }
    }
}
