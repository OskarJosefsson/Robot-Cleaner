using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Cleaner.Classes.Extensions
{
    public static class StringExtensions
    {

        public static string ReplaceSeveral(this string str , string [] charsToRemove)
        {
            foreach (var c in charsToRemove)
            {
                str = str.Replace(c, string.Empty);
            }
            return str;
        }
    }
}
