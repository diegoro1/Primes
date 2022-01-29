## Requirements

Before compiling the application please make you have the following installed:

* [mono](https://www.mono-project.com/download/stable/)

Make sure it is version 6.12.0.140 or compatible
```bash
mono -V
```

## Running the Program
Clone the repository and run the following commands:
```bash
cd Primes
make
make <parameters>
```

These are the current parameters:

* "slow": runs the slow multi threaded and single threaded algo, currently caps at 300,000 to prevent hours of running.
* "single": fires the fast single threaded algo algo.
* "run": runs the default application (currently only works with smaller numbers)



## Output

The output files are in the output directory. Currently, there are three outputs. 

* output.txt
* primes-single.txt
* primes-slow.txt 

The best functioning output that ran multiple threads would be "primes-slow.txt". It uses the undesired method of placing the threads within ranges. This method is not as efficient since the higher ranges have much fewer primes causing the threads working in the smaller ranges to do most of the work.

The output "primes-single.txt" does all the work in a single thread running the [Sieve of Eratosthenes](https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes) algorithm. This is the most efficient method within the project and the main goal was to make it more efficient by using multiple threads.

Output.txt is currently buggy as the calculations are bouncing out of bounds of the primes array. It works perfectly well with smaller outputs but it currently does not work with the 10^8 input.
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
[MIT](https://choosealicense.com/licenses/mit/)