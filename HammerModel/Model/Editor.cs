using System;

namespace HammerModel.Model
{
    public class Editor// : IDefaultable<Editor>
    {
        public IntTriple Color { get; set; }
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
                Color = new IntTriple
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