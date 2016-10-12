using HammerModel.Model.Textures;

namespace HammerModel.Model.Structures
{
    public abstract class TextureObject : WorldObject
    {
        public TexturePack TexturePack { get; set; }
    }
}