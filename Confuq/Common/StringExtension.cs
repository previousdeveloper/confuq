using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public static class StringExtension
    {

        public static Dictionary<string, string> SplitByKevValue(this string item)
        {
            Dictionary<string, string> result = item.Split(' ').ToDictionary(k => k.Split(':')[0], v => v.Split(':')[1]);

            return result;
        }
    }
}