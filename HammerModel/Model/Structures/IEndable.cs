using HammerModel.Model.Units;

namespace HammerModel.Model.Structures
{
    public interface IEndable
    {
        ValueTriple GetEndCoordinates(Portal portal);
    }
}
