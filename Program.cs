using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using ConsoleApp.TextSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    [RankColumn]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class Benchmark
    {
        private const string fullName = "Joakim von Anka";
        private static readonly NameParser parser = new NameParser();

        [Benchmark(Baseline = true)]
        public void GetLastName() => parser.GetLastName(fullName);

        [Benchmark]
        public void GetLastNameUsingSubString() => parser.GetLastNameUsingSubString(fullName);

        [Benchmark]
        public void GetLastNameWithSpan() => parser.GetLastNameWithSpan(fullName);
    }

    class NameParser
    {
        public string GetLastName(string fullName)
        {
            var names = fullName.Split(" ");
            var lastName = names.LastOrDefault();
            return lastName ?? string.Empty;
        }

        public string GetLastNameUsingSubString(string fullName)
        {
            var lastSpaceIndex = fullName.LastIndexOf(" ", StringComparison.Ordinal);

            return lastSpaceIndex == -1
                ? string.Empty
                : fullName.Substring(lastSpaceIndex + 1);
        }

        public ReadOnlySpan<char> GetLastNameWithSpan(ReadOnlySpan<char> fullName)
        {
            var lastSpaceIndex = fullName.LastIndexOf(' ');

            return lastSpaceIndex == -1
                ? ReadOnlySpan<char>.Empty
                : fullName.Slice(lastSpaceIndex + 1);
        }
    }

    class LocalPool
    {
        private readonly HashSet<string> stringPool = new HashSet<string>();

        public string GetOrCreate(string entry)
        {
            string result;
            if (!stringPool.TryGetValue(entry, out result))
            {
                stringPool.Add(entry);
                result = entry;
            }
            return result;
        }
    }

    class Index
    {
        internal void BuildIndex()
        {
            var allWords = list.Select((s) => pattern.Replace(s, "").ToLower()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries))
                .SelectMany((strings, i) => strings.Select(s1 => new { s1, i }))
                .Where(w => w.s1.Length > 3)
                .OrderBy(k => k.s1)
                .Distinct()
                .ToLookup(arg => arg.s1, arg => arg.i);

            foreach (var word in allWords)
            {
                Console.WriteLine(word.Key);
                foreach (var documentID in word)
                    Console.WriteLine("-" + documentID);
            }
        }

        //Build index, no stopwords used in this example.
        //Should exclude common words like is, the, a, an....
        //Now it just removes words with less than 3 characters
        static Regex pattern = new Regex("[.,;?!\t\r\n'`´]");

        static List<string> list = new List<string>()
            {
                "My sister is coming for the holidays.",
                "The holidays are a chance for family meeting.",
                "Who did your sister meet? Your other sister?",
                "It takes an hour to make fudge.",
                "My sister makes awesome fudge."
            };
    }

    class Program
    {
        static async Task Main(string[] args)
        {

            //new RegexExample().Run();
            //new Index().BuildIndex();
            //new IndexAndSearchExample().Run();
            new LuceneExample().Run();
            //var summary = BenchmarkRunner.Run(typeof(Benchmark));
        }
    }
}
