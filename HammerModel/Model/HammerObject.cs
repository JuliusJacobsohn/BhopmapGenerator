using HammerModel.Helpers;

namespace HammerModel.Model
{
    public abstract class HammerObject
    {
        private int _id = -1;
        protected int Id
        {
            get
            {
                if (_id == -1)
                {
                    _id = HONHelper.GetUniqueId();
                }
                return _id;
            }
        }
    }
}
