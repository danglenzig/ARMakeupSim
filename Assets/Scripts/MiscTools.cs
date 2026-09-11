using System.Collections.Generic;
using UnityEngine;

namespace MiscTools
{
    public static class StringTools
    {
        public static string StringListToString(List<string> inList)
        {
            string outStr = "{ ";
            foreach(string item in inList)
            {
                outStr += $"{item}, ";
            }
            outStr += " }";
            return outStr;
        }
    }
}

