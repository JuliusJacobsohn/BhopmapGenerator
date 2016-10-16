using HammerModel.Helpers;
using HammerModel.Model.Units;
using System.Collections.Generic;

namespace HammerModel.Model
{
    public abstract class HammerObject
    {
        private int _id = -1;
        protected List<RotationTask> Rotations = new List<RotationTask>();
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
        public void AddRotationTask(RotationType type, double degree, ValueTriple origin = null)
        {
            RotationTask newTask = new RotationTask
            {
                Degree = degree,
                RotationType = type
            };
            if (origin != null)
            {
                newTask.Origin = origin;
            }
            Rotations.Add(newTask);
        }
        public void AddRotationTask(RotationTask task)
        {
            Rotations.Add(task);
        }
        public void AddRotationTask(List<RotationTask> tasks)
        {
            Rotations.AddRange(tasks);
        }
    }
}
