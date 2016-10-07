using HammerModel.Model.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model
{
    public class Side
    {
        public int Id { get; set; }
        public CoordinateTriple Plane { get; set; }
        public string Material { get; set; }
        public Axis UAxis { get; set; }
        public Axis VAxis { get; set; }
        public double Rotation { get; set; }
        public double LightMapScale { get; set; }
        public int Smoothing_Groups { get; set; }

        public override string ToString()
        {
            return HONHelper.GetHonObjectBody("side",
                HONHelper.GetKeyValuePair("id", Id),
                HONHelper.GetKeyValuePair("plane", Plane),
                HONHelper.GetKeyValuePair("material", Material),
                HONHelper.GetKeyValuePair("uaxis", UAxis),
                HONHelper.GetKeyValuePair("vaxis", VAxis),
                HONHelper.GetKeyValuePair("rotation", Rotation),
                HONHelper.GetKeyValuePair("lightmapscale", LightMapScale),
                HONHelper.GetKeyValuePair("smoothing_groups", Smoothing_Groups));
        }
    }
}
