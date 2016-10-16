
using HammerModel.Model.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Structures
{
    public abstract class WorldObject
    {
        protected List<RotationTask> Rotations = new List<RotationTask>();
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

        public abstract ValueTriple GetOrigin();
        public abstract List<HammerObject> ToHammerObject();
    }
}
