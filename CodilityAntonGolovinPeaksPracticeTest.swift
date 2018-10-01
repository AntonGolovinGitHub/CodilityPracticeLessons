// https://app.codility.com/demo/results/trainingJKQHUU-79X/

import Foundation
import Glibc

// you can write to stdout for debugging purposes, e.g.
// print("this is a debug message")

public func solution(_ A : inout [Int]) -> Int {
    // write your code in Swift 3.0 (Linux)
    
    let lengthA : Int = A.count;
    
    // print("Found # of numbers ", lengthA);
    
    if(lengthA < 1 || lengthA > 100000) {
        return 0;
    }
    
    if(lengthA == 1) {
        return 0;
    }
    
    if(lengthA == 2) {
        return 0;
    }
    
    // handle some edge cases
    
    if(isHomogeneousOrOutOfBounds(A: &A, checkBounds: true)) {
        return 0;
    }
    
    var peaks : [Int:Int] = [:];
    
    findPeaks(peaks: &peaks, A: &A);

    // print("Found # peaks: ", peaks.keys.count);

    if(isPrime(N : lengthA) && peaks.keys.count > 0) {
        return 1;    
    }
    
    if(peaks.keys.count == 1) {
        return 1;    
    }
    
    let dividers = findAllDividers(A: &A);
    
    if(dividers.count == 0) {
        return 1;
    }

   var maxSegments : Int = 1;

   for V in dividers {

        let segmentLength = A.count / V;
        
        // print ("Found divider as ", V);
        // print ("Calculated segment length as ", segmentLength);

        let numberSegments : Int = 
        hasPeaks(peaks: &peaks, totalLength: A.count, segmentLength: segmentLength);
        
        // print("Number of Peaks = ", numberPeaks);
       
        if(numberSegments == -1) {
            continue;
        }
        
        if (numberSegments == V) {
            if(maxSegments < numberSegments) {
                maxSegments = numberSegments;
            }
        }
        
     }
     
   // print("Found max sagments = ", maxSegments);
   return maxSegments;
    
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

func hasPeak(peaks: inout [Int:Int], beginIncl : Int, endExcl : Int) -> Bool {
    
    if(beginIncl >= endExcl) {
        return false;
    }
    
    for V in beginIncl...(endExcl-1) {
        if(peaks[V] != nil) {
            return true;
        }
    }
    
    return false;

}

func hasPeaks(peaks: inout [Int:Int], totalLength : Int, segmentLength: Int) -> Int {
    
    if(totalLength < segmentLength) {
        return -1;
    }
    
    if(totalLength % segmentLength != 0) {
        return -1;
    }
    
    let iterations = totalLength / segmentLength;
    
    if(iterations < 1) {
        return -1;
    }

    var hasPeaks : Bool = true;

    for V in 0...(iterations - 1) {
    
        let hasPeaksThisSegment : Bool = hasPeak(peaks: &peaks, beginIncl: (V * segmentLength), endExcl: (V + 1) * (segmentLength));
        
        if(!hasPeaksThisSegment) {
            hasPeaks = false;
            break;
        }
        
    }
    
    if (hasPeaks == true) {
        return iterations;
        }
    else {
            return -1;
        }
        
}

func findPeaks(peaks: inout [Int:Int], A: inout [Int]) {
    // calculate positions of all the peaks for later
    
    let lengthA : Int = A.count;
    var ascending : Bool = false;
    var descending : Bool = false;
    
    for V in 1...(lengthA - 1) {
        if(A[V - 1] > A[V]) {
            descending = true;
            if(ascending && descending) {
                // print("Found a peak! ", A[V - 1], V - 1);
                peaks[V - 1] = A[V - 1];
            }
        } else {
            descending = false;
        }
        
        if(A[V - 1] < A[V]) {
            ascending = true;
        } else {
            ascending = false;
        }
    }
}

func isHomogeneousOrOutOfBounds(A: inout [Int], checkBounds : Bool) -> Bool {
    
    var sameValues : Bool = true;
    var alwaysAscending : Bool = true;
    var alwaysDescending : Bool = true;
    
    let lengthA : Int = A.count;
    
    for V in 0...(lengthA - 1) {
        if(checkBounds) {
            if(A[V] < 0 || A[V] > 1000000000) {
                return true;
            }
        }
        if(V >= 1 && A[V - 1] != A[V]) {
            sameValues = false;
        }
        
        if(V >= 1 && A[V - 1] > A[V]) {
            alwaysAscending = false;
        }
        
        if(V >= 1 && A[V - 1] < A[V]) {
            alwaysDescending = false;
        }
    }
    
    if(sameValues || (alwaysAscending || alwaysDescending)) {
        return true;
    }
    
    return false;
}

func findAllDividers(A: inout [Int]) -> [Int] {
    let lengthA : Int = A.count;
    var dividers : Set<Int> = Set<Int>();
    for V in 2...(lengthA - 1) {
        if(lengthA % V == 0) {
            // print("Found divider ", V, " for a segment length of ", lengthA / V);
            dividers.insert(V);           
        }
    }
    
    return dividers.sorted();
}