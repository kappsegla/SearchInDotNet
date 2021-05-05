using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class ImmutableClass
    {
        private int value;

        public ImmutableClass()
        {

        }
        public int Value
        {
            get { return this.value; }
            init { this.value = value; }
        }

        //Other code goes here like ToString, Equals....
    }

    record RecordType(int Value);


    class MultiThreading
    {
        List<string> list = new List<string>();

        public void TMethod()
        {
            int i = 0;
            while (i++ < 50)
            {
                list.Add(i.ToString());
                Console.WriteLine("Added a value");
                Thread.Sleep(100);
            }
        }

        public void TMethod(object o)
        {
            int i = 0;
            while (i++ < 50)
            {
                Console.Write("Hi ");
                Console.Write(" from ");
                Console.WriteLine(" thread");
                Thread.Sleep(100);
            }
        }


        public async Task<IEnumerable<int>> FetchIoTData()
        {
            List<int> data = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(1000);
                data.Add(i);
            }
            return data;
        }
        public async IAsyncEnumerable<int> FetchIoTDataAsync()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(1000);
                yield return i;
            }
        }


        public IEnumerable<int> Test()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
        }


        public async void Run()
        {

            //foreach (var dataPoint in await FetchIoTData())
            //{
            //    Console.WriteLine(dataPoint);
            //}
            await foreach (var dataPoint in FetchIoTDataAsync())
            {
                Console.WriteLine(dataPoint);
            }





            //ImmutableClass immutableClass =
            //    new ImmutableClass()
            //    {
            //        Value = 1
            //    };

            //var r = new RecordType(1);




            //int minimumWorkerThreadCount, minimumIOCThreadCount;
            //int logicalProcessorCount = System.Environment.ProcessorCount;

            //ThreadPool.GetMinThreads(out minimumWorkerThreadCount, out minimumIOCThreadCount);

            //Console.WriteLine("No.of processors: " + logicalProcessorCount);
            //Console.WriteLine("Minimum no.of Worker threads: " + minimumWorkerThreadCount);
            //Console.WriteLine("Minimum no.of IOCP threads: " + minimumIOCThreadCount);


            //Thread thread = new Thread(TMethod);
            //thread.Start();
            // ThreadPool.QueueUserWorkItem(TMethod);

            //int i = 0;
            //while (i++ < 50)
            //{
            //    Console.WriteLine("Hi from main thread");
            //    Thread.Sleep(100);
            //}






            //ThreadSafetyDemo();


            Console.Read();
        }


        private const int MaxThraedCount = 10;
        private Thread[] m_Workers = new Thread[MaxThraedCount];
        private Int32 x = 0;
        CountdownEvent cde = new CountdownEvent(MaxThraedCount);

        public void ThreadSafetyDemo()
        {
            Console.WriteLine("Starting...");

            for (int i = 0; i < MaxThraedCount; i++)
            {
                m_Workers[i] = new Thread(IncreaseNumber) { Name = "Thread " + (i + 1) };
                m_Workers[i].Start();
            }

            cde.Wait();
            Console.WriteLine("The result: " + x.ToString());
        }

        private readonly object obj = new object();

        [MethodImpl(MethodImplOptions.Synchronized)]
        void IncreaseNumber()
        {

            for (int i = 0; i < 10000; i++)
            {
                // Different strategy to increment x
                //x++;
                //Interlocked.Increment(ref x);
                //Monitor.Enter(obj);
                //try
                //{
                //    x++;
                //}
                //finally
                //{
                //    Monitor.Exit(obj);
                //}
                lock (obj)
                {
                    x++;
                }
            }
            cde.Signal();

        }
    }
}
