// https://app.codility.com/demo/results/trainingTB27BY-JXQ/

// solution from CodeSays, reworked in Swift

import Foundation
import Glibc

// you can write to stdout for debugging purposes, e.g.
// print("this is a debug message")

public func solution(_ A : inout [Int]) -> Int {
    // write your code in Swift 3.0 (Linux)
    
    if(A == nil) {
        return -1;
    }
    
    let lengthA : Int = A.count;
    
    if(lengthA < 1 || lengthA > 400000) {
        return -1;
    }
    
    if(lengthA == 1) {
        return 0;
    }
    
    for K in 0...(lengthA-1) {
        if(A[K] < 0 || A[K] > 1000000000) {
            return -1;
        }
    }
    
    let debug : Bool = false;
    
    let peaks = findPeaks(A: &A);
    
    let numberPeaks = peaks.count;
    
    if(numberPeaks == 0) {
        return 0;
    }
    
    if(numberPeaks == 1) {
        return 1;
    }
    
    var max : Int = Int(Float(lengthA).squareRoot()) + 1;
    
    if(debug) { print("Found max # flags settable as ", max); }

    var sortedPeaks = peaks.keys.sorted();
    
    if(debug) { print("Sorted peak indexes = ", sortedPeaks); }
    
    var lengthB : Int = sortedPeaks.count;
    
    var result : Int = 0;
    
    main:
    for V in (0...max).reversed() {    
            
            var numberFlags : Int = 1;
            
            var lastPeakIndex : Int = sortedPeaks[0];

            inner:
            for Z in (1...(lengthB-1)) {

                var dist : Int = Swift.abs(sortedPeaks[Z] - lastPeakIndex);
                
                if(dist >= V) {
                    numberFlags = numberFlags + 1;
                    lastPeakIndex = sortedPeaks[Z];
                    if(numberFlags == V) {
                        result = numberFlags;
                        break main;
                    }
                    if(debug) { print("Found another flag at peak index = ", lastPeakIndex); }
                } else {
                    if(debug) { print("Skipping non-flaggable peak at index = ", sortedPeaks[Z]); }
                    continue inner;
                }
                
                if(debug) { print("lastPeakIndex = ",lastPeakIndex); }

            }

    }
    
    return result;
    
    
}

func findPeaks(A: inout [Int]) -> [Int:Int] {

    let lengthA : Int = A.count;
    
    var peaks : [Int:Int] = [Int:Int]();

    for V in 1...(lengthA - 2) {
        if((A[V] > A[V - 1]) && (A[V] > A[V + 1])) {
             if(peaks[V] == nil) {
                  peaks[V] = A[V];
             }
        }
    }
    // print("Peaks = ", peaks);    
    return peaks;
}