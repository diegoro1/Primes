default:
	mcs -out:main.exe main.cs Eratosthenes.cs PrimeHandler.cs SlowPrime.cs

run:
	mono main.exe

slow:
	mono main.exe slow