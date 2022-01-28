using System;
using System.Linq;
using System.Diagnostics;

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
    }

}