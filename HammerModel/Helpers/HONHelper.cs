using HammerModel.Model;
using HammerModel.Model.Structures;
using HammerModel.Model.Units;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Helpers
{
    public class HONHelper
    {
        public static int IdCounter = 0;
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int GetUniqueId()
        {
            int returnId = IdCounter;
            IdCounter++;

            return returnId;
        }

        public static string GetTeleportName(int id)
        {
            return "teleport_destination_" + id;
        }

        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }

        public static string GetKeyValuePair(string key, object value)
        {
            if (value.GetType() == typeof(double))
            {
                double sValue = (double)value;
                return "\"" + key + "\" \"" + sValue.ToString(CultureInfo.InvariantCulture) + "\"";
            }
            return "\"" + key + "\" \"" + value.ToString() + "\"";
        }

        public static string GetHonObjectBody(string name, params string[] content)
        {
            string contentString = "";
            foreach (var con in content)
            {
                contentString = contentString + "\t" + con + "\n";
            }
            return name + "\n" +
                "{\n" + contentString + "}";
        }

        public static List<HammerObject> ToHammerObject(List<RotationTask> rotations, params WorldObject[] objects)
        {
            List<HammerObject> objectList = new List<HammerObject>();
            foreach (var obj in objects)
            {
                obj.AddRotationTask(rotations);
                objectList.AddRange(obj.ToHammerObject());
            }
            return objectList;
        }
    }
}
