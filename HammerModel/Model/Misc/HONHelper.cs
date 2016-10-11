using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerModel.Model.Misc
{
    public class HONHelper
    {
        public static int IdCounter = 0;
        public static int GetUniqueId()
        {
            int returnId = IdCounter;
            IdCounter++;

            return returnId;
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
    }
}
