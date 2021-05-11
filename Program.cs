using BenchmarkDotNet.Running;
using ConsoleApp2.Examples;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Debug.WriteLine("Debug message");
            Trace.WriteLine("Trace message");

            //DebugExample.Run();

            var result = new DebugLinq().MyQuery(DebugLinq.employees);

            //To run benchmark compile with release and start without debugger, Ctrl + F5
            //var summary = BenchmarkRunner.Run(typeof(BenchmarkSpan));

            Console.Read();
        }
    }
}
