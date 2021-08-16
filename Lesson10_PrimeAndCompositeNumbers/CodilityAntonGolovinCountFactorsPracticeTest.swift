// https://app.codility.com/demo/results/trainingNAZ93H-EZ3/

import Foundation
import Glibc

// you can write to stdout for debugging purposes, e.g.
// print("this is a debug message")

public func solution(_ N : Int) -> Int {
    // write your code in Swift 3.0 (Linux)
    
    if(N < 1) {
        return 0;
    }
    
    if(N == 1) {
        return 1;
    }
    
    if(N == 2) {
        return 2;
    }
    
    if(isPrime(N: N)) {
        return 2;
    }
    
    var LeastDivider: Int = -1;

    var Number: Int = N;

    var primes: [Int:Int] = [:];

    while(true) {
        // always going to be a prime number
        if(N < 2) {
            break;
        }
        LeastDivider = leastDivider(N: Number);
        if(LeastDivider == -1) {
            return 0;
        }
        addToPrimesCount(Primes: &primes, Number: LeastDivider);
        Number = Number / LeastDivider;
        if(isPrime(N: Number)) {
            addToPrimesCount(Primes: &primes, Number: Number);
            break;
        }
    }
    
    return getDividersCount(Primes: primes);

}



func isPrime(N: Int) -> Bool {
    if N <= 1 {
        return false;
        }
    if N <= 3 {
        return true;
        }
    var i: Int = 2;
    while i*i <= N {
        if N % i == 0 {
           return false;
        }
        i = i + 1;
    }
    return true;
}

func leastDivider(N: Int) -> Int {

    if(N < 2) {
        return -1;
    }

    for V in 2...N {
        if(N % V == 0) {
            return V;
        }
    }
    return -1;
}

func addToPrimesCount(Primes: inout [Int:Int], Number: Int) {
    if(Primes[Number] == nil) {
        Primes[Number] = 0;
    }
    Primes[Number] = Primes[Number]! + 1;
}

func getDividersCount(Primes:[Int:Int]) -> Int {
    var result : Int = -1;
    for myValue  in Primes.values {
        if(result == -1) {
            result = (1 + myValue);
        } else {
            result *= (1 + myValue);    
        }
    }

    return result;
}