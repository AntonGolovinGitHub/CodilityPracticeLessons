// https://app.codility.com/demo/results/trainingTQ3AHB-VJ9/

import Foundation
import Glibc

// you can write to stdout for debugging purposes, e.g.
// print("this is a debug message")

public func solution(_ A : Int, _ B : Int, _ K : Int) -> Int {
    // write your code in Swift 3.0 (Linux)
    
    if(A < 0 || A > 2000000000) {
        return 0;
    }
    
    if(B < 0 || B > 2000000000) {
        return 0;
    }
    
    if(K < 1 || K > 2000000000) {
        return 0;
    }
    
    if(A > B) {
        return 0;
    }
    
    if(A == B) {
        return (A % K == 0) ? 1 : 0;
    }
    
    var count:Int = 0;
    
    var divisible:Int = 0;
    
    for Z in A...B {
        if((Z % K) == 0) {
            divisible = Z;
            count = 1;
            break;
        }
    }
    
    count = count + ((B - divisible) / K)
    
    return count;
    
}
