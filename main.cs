using System;
using Eratosthenes;
using PrimeUtil;
using System.IO;
using System.Collections.Generic;


class PrimeFinder
{
    static void Main(string[] args)
    {
        if (args.Length > 0 && args[0].Equals("slow"))
        {
            string fileName = "./output/primes-slow.txt";
            try
            {
                if (File.Exists(fileName))
                    File.Delete(fileName);

                using (StreamWriter stream = File.CreateText(fileName))
                {
                    stream.WriteLine("Slow Find Prime.\n");
                    stream.WriteLine("Only using a small range since it would take forver...(0-300000)");

                    SlowPrime slowPrime = new SlowPrime(300000);
                    slowPrime.FindPrimes();

                    double runtime = slowPrime.Runtime;
                    stream.Write(String.Format("{0}ms ", runtime));

                    int totalPrimes = slowPrime.Primes.Count;
                    stream.Write(String.Format("{0} ", totalPrimes));

                    double sumOfPrimes = slowPrime.SumOfPrimes();
                    stream.WriteLine(String.Format("{0}", sumOfPrimes));

                    slowPrime.Primes.Sort();
                    for (int i = totalPrimes - 11; i < totalPrimes; i++)
                        stream.Write(String.Format("{0} ", slowPrime.Primes[i]));

                    stream.WriteLine("\n\nUsing multiple threads\n");

                    SlowPrime notSoSlowPrime = new SlowPrime(300000);
                    notSoSlowPrime.FindPrimesThreaded();

                    runtime = notSoSlowPrime.Runtime;
                    stream.Write(String.Format("{0}ms ", runtime));

                    totalPrimes = notSoSlowPrime.Primes.Count;
                    stream.Write(String.Format("{0} ", totalPrimes));

                    sumOfPrimes = notSoSlowPrime.SumOfPrimes();
                    stream.WriteLine(String.Format("{0}", sumOfPrimes));

                    notSoSlowPrime.Primes.Sort();
                    for (int i = totalPrimes - 11; i < totalPrimes; i++)
                        stream.Write(String.Format("{0} ", notSoSlowPrime.Primes[i]));

                }

            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
        }


    }
}