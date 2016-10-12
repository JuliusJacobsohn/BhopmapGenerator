using HammerModel.Helpers;

namespace HammerModel.Model
{
    public abstract class HammerObject
    {
        protected int Id
        {
            get
            {
                return HONHelper.GetUniqueId();
            }
        }
    }
}
