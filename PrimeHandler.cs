using System;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;

namespace PrimeUtil
{
    class PrimeHandler
    {
        public int Length { get; set; }
        public List<int> Primes { get; set; } = new List<int>();

        public double Runtime { get; set; }

        public PrimeHandler(int length = 100000000)
        {
            Length = length;
        }

        public bool isPrime(int n)
        {
            if (n < 2)
                return false;

            for (int i = 2; i < n; i++)
                if (n % i == 0)
                    return false;

            return true;
        }

        public void PrintPrimes()
        {
            foreach (int prime in Primes)
                Console.Write(String.Format("{0}, ", prime));
        }

        public double SumOfPrimes()
        {
            double sum = 0;
            foreach (int prime in Primes)
                sum += prime;

            return sum;
        }
    }
}
