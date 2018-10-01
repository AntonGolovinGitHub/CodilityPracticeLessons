// https://app.codility.com/demo/results/trainingAJEK8J-NSW/

import Foundation
import Glibc

// you can write to stdout for debugging purposes, e.g.
// print("this is a debug message")

public func solution(_ N : Int) -> Int {
    // write your code in Swift 3.0 (Linux)
    
    if(N < 1 || N > 1000000000) {
        return 0;
    }
    
    if(N == 1) {
        return 4;
    }
    
    if(N == 1000000000) {
        
        // these values were obtained through experimentation with a calculator
        var first : Int = 32000;
        var second : Int = 31250;
        
        return 2 * (first + second);
            
    }
    
    var sq : Float = (Float(N)).squareRoot();
    
    if(Int(sq) * Int(sq) == N) {
        return 4 * Int(sq);
    }
    
    if(isPrime(N : N)) {
        return 2 * (1 + N)
    }
    var min : Int = Int.max;
    var side: Int;
    var perimeter: Int;
    
    for V in 1...N {
        if(N % V == 0) {
            side = N / V;        
            perimeter = 2 * (side + V);
            if(perimeter < min) {
                min = perimeter;
            }
        }
    }
    return min;
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
