using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace What2Cook
{
    public class Utility
    {
        public static void SetParameter(Dictionary<string, string> uriParams, string key, string value)
        {
            string val;

            uriParams.TryGetValue(key, out val);
            if (val == null)
            {
                uriParams.Add(key, value);
            }
            else
            {
                uriParams[key] = value;
            }
        }
    }
}
