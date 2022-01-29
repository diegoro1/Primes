using System;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;

namespace PrimeUtil
{
    class SlowPrime : PrimeHandler
    {
        public SlowPrime(int length) : base(length) { }

        public void FindPrimes()
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int i = 2; i < Length; i++)
                if (isPrime(i))
                    Primes.Add(i);

            stopwatch.Stop();
            Runtime = stopwatch.ElapsedMilliseconds;
        }

        private void FindPrimesInRange(int start, int end)
        {
            for (int i = start; i < end; i++)
                if (isPrime(i))
                    Primes.Add(i);
        }

        public void FindPrimesThreaded()
        {
            int[] ranges = new int[9];

            for (int i = 0; i < 8; i++)
                ranges[i] = ((Length - 1) / 8) * i;

            ranges[8] = Length;

            // foreach (int range in ranges)
            //     Console.Write(String.Format("{0}, ", range));

            Thread[] threads = new Thread[8];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 8; i++)
            {
                int local_counter = i;
                threads[i] = new Thread(() =>
                {
                    FindPrimesInRange(ranges[local_counter],
                    ranges[local_counter + 1]);
                });
                threads[i].Start();
            }

            for (int i = 0; i < 8; i++)
                threads[i].Join();

            stopwatch.Stop();
            Runtime = stopwatch.ElapsedMilliseconds;
        }
    }
}