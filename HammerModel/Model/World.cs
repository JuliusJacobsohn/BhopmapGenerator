using HammerModel.Model.Misc;
using System.Collections.Generic;

namespace HammerModel.Model
{
    public class World
    {
        public int Id { get; set; }
        public int MapVersion { get; set; }
        public string ClassName { get; set; }
        public string DetailMaterial { get; set; }
        public string DetailVbsp { get; set; }
        public int MaxPropScreenWidth { get; set; }
        public string SkyName { get; set; }
        public List<Solid> Solids { get; set; }
        public List<Editor> Groups { get; set; }
        public override string ToString()
        {
            string solidString = "";
            foreach (Solid solid in Solids)
            {
                solidString = solidString + solid.ToString() + "\n";
            }
            string groupString = "";
            foreach (Editor editor in Groups)
            {
                groupString = groupString + editor.ToString() + "\n";
            }

            return HONHelper.GetHonObjectBody("world",
                HONHelper.GetKeyValuePair("id", Id),
                HONHelper.GetKeyValuePair("mapversion", MapVersion),
                HONHelper.GetKeyValuePair("classname", ClassName),
                HONHelper.GetKeyValuePair("detailmaterial", DetailMaterial),
                HONHelper.GetKeyValuePair("detailvbsp", DetailVbsp),
                HONHelper.GetKeyValuePair("maxpropscreenwidth", MaxPropScreenWidth),
                HONHelper.GetKeyValuePair("skyname", SkyName),
                solidString,
                groupString);
        }
    }
}