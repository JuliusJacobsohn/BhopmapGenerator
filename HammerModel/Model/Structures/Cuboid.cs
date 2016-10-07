using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BhopmapGenerator.Model.Structures
{
    public class Cuboid : IWorldObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Width { get; set; }
        public double Breadth { get; set; }
        public double Height { get; set; }
        private TextureInfo _textureInfo { get; set; }
        public TextureInfo TextureInfo
        {
            get
            {
                return _textureInfo == null ? TextureInfo.GetDefault() : _textureInfo;
            }
            set
            {
                _textureInfo = value;
            }
        }

        public List<Solid> ToWorldObject()
        {
            List<Solid> cubeList = new List<Solid>();

            cubeList.Add(new Solid(X, Y, Z, Width, Breadth, Height, TextureInfo));

            return cubeList;
        }
    }
}
