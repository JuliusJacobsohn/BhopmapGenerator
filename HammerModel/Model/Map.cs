using HammerModel.Model.Entities;
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
        public Map(bool hasEnviromentLight = true)
        {
            World = new World
            {
                MapVersion = 1,
                ClassName = "worldspawn",
                DetailMaterial = "detail/detailsprites",
                DetailVbsp = "detail.vbsp",
                MaxPropScreenWidth = -1,
                SkyName = "sky_dust",
                Solids = new List<HammerObject>(),
                Groups = new List<Editor>()
            };
            Entities = new List<HammerObject>();
            if (hasEnviromentLight)
            {
                WorldEnviromentLight light = new WorldEnviromentLight
                {
                    R = 255,
                    G = 255,
                    B = 255,
                    A = 200
                };
                AddWorldObject(light);
            }
        }
        public World World { get; set; }
        public List<HammerObject> Entities { get; set; }
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

        public void AddWorldObject(WorldObject o)
        {
            foreach(HammerObject ho in o.ToHammerObject())
            {
                if(ho is Entity)
                {
                    Entities.Add(ho);
                }
                else
                {
                    World.Solids.Add(ho);
                }
            }
        }
    }
}
