using System;
using Eratosthenes;


class HelloWorld
{
    static void Main()
    {
        bool[] primes = Eratosthenes.Primes.FindPrimes(100000000);
        double total = 0;
        for (int i = 2; i < primes.Length; i++)
            if (primes[i] == true)
                total += i;
        System.Console.WriteLine(total);
    }
}