using System;
using System.Linq;
using System.Diagnostics;
using System.Threading;

namespace Eratosthenes
{
    class Primes
    {
        public static bool[] FindPrimes(int size)
        {
            bool[] primes = Enumerable.Repeat(true, size).ToArray();
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int i = 2; i * i < size; i++)
                if (primes[i] == true)
                    for (int j = i * i; j < size; j += i)
                        primes[j] = false;
            stopwatch.Stop();

            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);

            return primes;
        }

        private static void FindPrimesInRange(int start, int end, bool[] primes)
        {
            if (start < 2)
                start = 2;
            if (end > primes.Length)
                end = primes.Length;

            Console.WriteLine(String.Format("start: {0}, end: {1}", start, end));

            for (int i = start; i * i < end; i++)
                if (primes[i] == true)
                    for (int j = i * i; j < end; j += i)
                        primes[j] = false;

        }

        private static void FindPrimesByMultiple(int n, bool[] primes)
        {
            for (int i = n; i < primes.Length; i += 10)
                for (int j = i * i; j < primes.Length; j += i)
                    primes[j] = false;
        }

        // anything that ends in 0,2 is not prime
        // then divide work with nums ending in: 1,3,4,5,6,7,8

        // multiples of 2,3,5,7 that matter
        public static bool[] FindPrimesThreadedSimple(int size)
        {
            bool[] primes = Enumerable.Repeat(true, size).ToArray();
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            Thread t1 = new Thread(() => { FindPrimesByMultiple(2, primes); });
            Thread t2 = new Thread(() => { FindPrimesByMultiple(3, primes); });
            Thread t3 = new Thread(() => { FindPrimesByMultiple(4, primes); });
            Thread t4 = new Thread(() => { FindPrimesByMultiple(5, primes); });
            Thread t5 = new Thread(() => { FindPrimesByMultiple(6, primes); });
            Thread t6 = new Thread(() => { FindPrimesByMultiple(7, primes); });
            Thread t7 = new Thread(() => { FindPrimesByMultiple(8, primes); });
            Thread t8 = new Thread(() => { FindPrimesByMultiple(9, primes); });

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();
            t6.Start();
            t7.Start();
            t8.Start();

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
            t5.Join();
            t6.Join();
            t7.Join();
            t8.Join();
            stopwatch.Stop();

            Console.WriteLine("Elapsed Time is {0} ms, using simple 8 threaded solution", stopwatch.ElapsedMilliseconds);

            return primes;
        }


        public static bool[] FindPrimesThreaded(int size, int numOfThreads = 8)
        {
            bool[] primes = Enumerable.Repeat(true, size).ToArray();
            Stopwatch stopwatch = new Stopwatch();

            int[] ranges = new int[numOfThreads];
            for (int i = 1; i <= numOfThreads; i++)
            {
                ranges[i - 1] = (int)Math.Sqrt(size) / numOfThreads * i;
            }

            stopwatch.Start();
            Thread t1 = new Thread(() => { FindPrimesInRange(0, ranges[0], primes); });
            Thread t2 = new Thread(() => { FindPrimesInRange(ranges[0], ranges[1], primes); });
            Thread t3 = new Thread(() => { FindPrimesInRange(ranges[1], ranges[2], primes); });
            Thread t4 = new Thread(() => { FindPrimesInRange(ranges[2], ranges[3], primes); });
            Thread t5 = new Thread(() => { FindPrimesInRange(ranges[3], ranges[4], primes); });
            Thread t6 = new Thread(() => { FindPrimesInRange(ranges[4], ranges[5], primes); });
            Thread t7 = new Thread(() => { FindPrimesInRange(ranges[5], ranges[6], primes); });
            Thread t8 = new Thread(() => { FindPrimesInRange(ranges[6], ranges[7], primes); });

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();
            t6.Start();
            t7.Start();
            t8.Start();

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
            t5.Join();
            t6.Join();
            t7.Join();
            t8.Join();
            stopwatch.Stop();

            Console.WriteLine("Elapsed Time is {0} ms, using simple 8 threaded solution", stopwatch.ElapsedMilliseconds);

            return primes;
        }

        public static void LogSumOfPrimes(bool[] primes)
        {
            double total = 0;
            for (int i = 2; i < primes.Length; i++)
                if (primes[i] == true)
                    total += i;
            System.Console.WriteLine(total);
        }

        public static void LogPrimes(bool[] primes)
        {
            for (int i = 2; i < primes.Length; i++)
                if (primes[i] == true)
                    Console.Write(String.Format("{0} ", i));

            System.Console.WriteLine(" ");
        }
    }

}