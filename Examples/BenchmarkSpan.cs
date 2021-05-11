using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Examples
{
    [RankColumn]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class BenchmarkSpan
    {
        [Benchmark(Baseline = true)]
        public byte Create1()
        {
            var array = new byte[] { 1, 2, 3, 4 };
            return array[0];
        }

        [Benchmark]
        public byte Create2()
        {
            ReadOnlySpan<byte> array = new byte[] { 1, 2, 3, 4 };
            return array[0];
        }
    }
}
