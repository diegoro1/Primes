using System;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;

namespace Eratosthenes
{
    class Primes
    {
        public static (bool[], double) FindPrimes(int size)
        {
            bool[] primes = Enumerable.Repeat(true, size).ToArray();
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int i = 2; i * i < size; i++)
                if (primes[i] == true)
                    for (int j = i * i; j < size; j += i)
                        primes[j] = false;
            stopwatch.Stop();

            return (primes, stopwatch.ElapsedMilliseconds);
        }

        private static void FindPrimesByMultiple(int n, bool[] primes)
        {
            try
            {
                for (int i = n; i < primes.Length; i += 10)
                    for (int j = i * i; j < primes.Length; j += 1)
                        primes[j] = false;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                return;
            }
        }

        public static (bool[], double) FindPrimesThreadedSimple(int size)
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

            return (primes, stopwatch.ElapsedMilliseconds);
        }

        public static double SumPrimes(bool[] primes)
        {
            double total = 0;
            for (int i = 2; i < primes.Length; i++)
                if (primes[i] == true)
                    total += i;
            return total;
        }

        public static void LogPrimes(bool[] primes)
        {
            for (int i = 2; i < primes.Length; i++)
                if (primes[i] == true)
                    Console.Write(String.Format("{0} ", i));

            System.Console.WriteLine(" ");
        }

        public static List<int> GetLastTen(bool[] primes)
        {
            List<int> lastTen = new List<int>();

            for (int i = primes.Length - 1; i >= 0; i--)
            {
                if (lastTen.Count >= 10)
                    break;

                if (primes[i] == true)
                    lastTen.Add(i);
            }

            return lastTen;
        }
    }

}