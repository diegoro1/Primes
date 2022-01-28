using System;
using Eratosthenes;


class PrimeFinder
{
    static void Main()
    {
        bool[] primes = Eratosthenes.Primes.FindPrimes(2000);
        Eratosthenes.Primes.LogSumOfPrimes(primes);

        bool[] primes2 = Eratosthenes.Primes.FindPrimesThreadedSimple(2000);
        Eratosthenes.Primes.LogSumOfPrimes(primes2);

        bool[] primes3 = Eratosthenes.Primes.FindPrimesThreaded(2000);
        Eratosthenes.Primes.LogSumOfPrimes(primes3);

        // Eratosthenes.Primes.LogPrimes(primes);
        // Eratosthenes.Primes.LogPrimes(primes2);
        // Eratosthenes.Primes.LogPrimes(primes3);
    }
}