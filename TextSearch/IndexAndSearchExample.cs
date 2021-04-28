using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp.TextSearch
{
    public class IndexAndSearchExample
    {

        public void Run()
        {

            var list = new List<string>()
            {
                "My sister is coming for the holidays.",
                "The holidays are a chance for family meeting.",
                "Who did your sister meet? Your other sister?",
                "It takes an hour to make fudge.",
                "My sister makes awesome fudge."
            };

            //Build index, no stopwords used in this example.
            //Should exclude common words like is, the, a, an....
            //Now it just removes words with less than 3 characters
            //var pattern = new Regex("[.,;?!\t\r\n]");

            //var allWords = list.Select((s) => pattern.Replace(s, "").ToLower()
            //        .Split(" ", StringSplitOptions.RemoveEmptyEntries))
            //    .SelectMany((strings, i) => strings.Select(s1 => new { s1, i }))
            //    .Where(w => w.s1.Length > 3)
            //    .OrderBy(k => k.s1)
            //    .Distinct()
            //    .ToLookup(arg => arg.s1, arg => arg.i);

            ////List our index
            //foreach (var h in allWords)
            //{
            //    h.Key.Dump();
            //    foreach (var d in h)
            //        Console.WriteLine(d);
            //    "--".Dump();
            //}

            // Search for strings containing an exact term. 
            //var searchTerm = "sister";

            //foreach (var o in allWords[searchTerm])
            //{
            //    list[o].Dump("Document: ");
            //}


            //////////////////////////////////////////////////////////////////////////
            //Fuzzy Searching

            //var stringDist = new JaroWinklerDistance();
            var stringDist = new LevenshteinDistance();

            ////Fuzzy Search
            //var searchResult = allWords.Select(key => new { d = stringDist.GetDistance(key.Key, "meeti"), key })
            //    .OrderByDescending(j => j.d);

            //foreach (var o in searchResult.Where(d => d.d > 0.5))
            //{
            //    o.d.Dump("Match");
            //    o.key.Key.Dump("Key");

            //}
            //////////////////////////////////////////////////////////////////////////

            //var result = list.Select(key => new { d = stringDist.GetDistance(key, "sister"), key })
            //    .OrderByDescending(j => j.d);

            //foreach (var o in result)
            //{
            //    o.d.Dump("Match");
            //    o.key.Dump("Key");
            //}


            ////How well does different wrongly spelled names match using our selected distance method
            ////https://www.joyofdata.de/blog/comparison-of-string-distance-algorithms/
            var kramer = new List<string>()
            {
                "Cosmo Kramer",
                "Kosmo Kramer",
                "Comso Kramer",
                "Csmo Kramer",
                "Cosmo X. Kramer",
                "Kramer, Cosmo",
                "Jerry Seinfeld",
                " CKaemmoorrs",
                "Cosmer Kramo",
                "Kosmoo Karme",
                "George Costanza",
                "Elaine Benes",
                "Dr. Van Nostren",
                "remarK omsoC",
                "Mr. Kramer",
                "Sir Cosmo Kramer",
                "C.o.s.m.o. .K.r.a.m.e.r",
                "CsoKae",
                "Coso Kraer"
            };

            foreach (var cosmo in kramer)
            {
                cosmo.Dump();
                stringDist.GetDistance("Cosmo Kramer", cosmo).Dump();
            }
        }
    }
}