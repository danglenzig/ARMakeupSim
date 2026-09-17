using System.Collections.Generic;
using UnityEngine;
using UnityRandom = UnityEngine.Random;

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

    public static class ColorTools
    {
        public static Color GetRandomColor()
        {
            Color outColor = new Color();

            float randoR = UnityRandom.Range(0.0f, 1.0f);
            float randoG = UnityRandom.Range(0.0f, 1.0f);
            float randoB = UnityRandom.Range(0.0f, 1.0f);

            outColor.r = randoR;
            outColor.g = randoG;
            outColor.b = randoB;
            outColor.a = 1.0f;

            return outColor;
        }
    }

}

