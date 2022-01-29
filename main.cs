using System;
using Eratosthenes;
using PrimeUtil;


class PrimeFinder
{
    static void Main(string[] args)
    {
        if (args.Length > 0 && args[0].Equals("slow"))
        {
            SlowPrime slowPrime = new SlowPrime(3000);
            slowPrime.FindPrimes();
            Console.WriteLine(slowPrime.SumOfPrimes());
            // slowPrime.PrintPrimes();
            Console.WriteLine(slowPrime.Runtime);

            System.Console.WriteLine("----");

            SlowPrime slowPrimeThreaded = new SlowPrime(3000);
            slowPrimeThreaded.FindPrimesThreaded();
            Console.WriteLine(slowPrimeThreaded.SumOfPrimes());
            // slowPrimeThreaded.PrintPrimes();
            Console.WriteLine(String.Format("miliseocnds: {0}", slowPrimeThreaded.Runtime));
        }


    }
}