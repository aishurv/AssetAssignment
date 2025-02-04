using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.ExtensionMethods
{
    public static class ListExtension
    {
        public static string GetLatestSeries(this string s1, string s2)
        {
            if (s1 == null) return s2;
            if (s2 == null) return s1;
            var n1 = int.Parse(s1[1..]); //var n1 = int.Parse(s1.Substring(1));
            var n2 = int.Parse(s2[1..]); // var n2 = int.Parse(s2.Substring(1));

            return n1 > n2 ? s1 : s2;
        }
    }
}
