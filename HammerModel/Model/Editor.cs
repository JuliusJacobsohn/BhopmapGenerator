using HammerModel.Helpers;
using HammerModel.Model.Textures;
using HammerModel.Model.Units;
using System;

namespace HammerModel.Model
{
    public class Editor// : IDefaultable<Editor>
    {
        public ValueTriple Color { get; set; }
        public int VisGroupShown { get; set; }
        public int VisGroupAutoShown { get; set; }
        public override string ToString()
        {
            return HONHelper.GetHonObjectBody("editor",
                HONHelper.GetKeyValuePair("color", Color),
                HONHelper.GetKeyValuePair("visgroupshown", VisGroupShown),
                HONHelper.GetKeyValuePair("visgroupautoshown", VisGroupAutoShown));
        }

        public static Editor GetDefault()
        {
            return new Editor
            {
                Color = new ValueTriple
                {
                    X = 0,
                    Y = 246,
                    Z = 187
                },
                VisGroupShown = 1,
                VisGroupAutoShown = 1
            };
        }
    }
}