using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp.TextSearch
{
    class RegexExample
    {
        private static Regex hrefRegex = new Regex("\\s*<a\\s*href\\s*=\\s*(?:\"(?<link>[^\"]*)\"|(?<link>\\S+))\\s*>(?<name>.*)\\s*</a>\\s*", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public static bool TryGetHrefDetails(string htmlTd, out string link, out string name)
        {
            var matches = hrefRegex.Match(htmlTd);
            if (matches.Success)
            {
                link = matches.Result("${link}");
                name = matches.Result("${name}");
                return true;
            }
            else
            {
                link = null;
                name = null;
                return false;
            }
        }

        public void Run()
        {
            //{ hello}
            //{ gray, grey}
            //{ zzz}
            //{ 0,1,2,3,4,5,6,7,8,9}
            //{ zzz, zzzz, zzzzz, …}
            //an 11 - digit string starting with a 1
            //begins with "dog"
            //ends with "dog"
            //is exactly "dog"

            //string pattern = @"cats?";
            //string text = "My cats and your.";

            //var regex = new Regex(pattern);
            //Console.WriteLine(regex.Match(text).Value);
















            //string pattern = @"\b\w+es\b";
            //Regex rgx = new Regex(pattern);
            //string sentence = "Who writes these notes?";

            //foreach (Match match in rgx.Matches(sentence))
            //    Console.WriteLine("Found '{0}' at position {1}",
            //                      match.Value, match.Index);





            //var st = "<td><a href ='/path/to/file'>Name of File</a></td>";
            //string link;
            //string name;

            //TryGetHrefDetails(st, out link, out name);
            //link.Dump();
            //name.Dump();



            //Evil regex, will timeout.Denial of Service
            var regex = new Regex("^(([a-z])+.)+[A-Z]([a-z])+$",
                RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture, TimeSpan.FromSeconds(2));
            string s = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa!";

            regex.IsMatch(s);

        }
    }
}
