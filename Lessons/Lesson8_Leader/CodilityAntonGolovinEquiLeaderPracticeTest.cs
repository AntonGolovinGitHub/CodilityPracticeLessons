// https://app.codility.com/demo/results/trainingS5WU6K-AMH/

using System;
using System.Collections.Generic;
using System.Linq;

// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {

    public int solution(int[] A) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        
        if(A == null)
            return 0;
         
        var lengthA = A.Length;
         
        if(lengthA < 1 || lengthA > 100000)
            return 0;
            
        if(lengthA == 1)
            return 0;
            
        if(lengthA == 2) {
            if (A[0] == A[1])
                return 1;
        }
        
        IDictionary<int, int> dict = new Dictionary<int, int>();
        
        for (var i = 0; i < lengthA; i++) {
               if(A[i] < -1000000000 || A[i] > 1000000000)
                    return 0;
               if(dict.ContainsKey(A[i])) {
                   dict[A[i]] = dict[A[i]] + 1;
               } else
                dict[A[i]] = 1;
        }
           
        var maxValue = dict.Aggregate((l, r) => l.Value > r.Value ? l : r).Value;

        // Console.WriteLine("maxValue: " + maxValue);

        if((lengthA - maxValue) >= maxValue)
            return 0;
        
        var maxKey = dict.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

        // Console.WriteLine("maxKey: " + maxKey);
        
        // now, find out the number of sequences where maxKey > half all keys
        
        var numberEquileaders = 0;
        
        var numberMaxKeysSeen = 0;
        var numberMaxKeysRemaining = 0;
        
        var numberKeysSeen = 0;
        var numberKeysRemaining = 0;
        
        for (var i = 0; i < lengthA; i++) {
            
            if(A[i] == maxKey) {
                numberMaxKeysSeen++;
                numberMaxKeysRemaining = maxValue - numberMaxKeysSeen;
            }
            
            if(i == 0 && numberMaxKeysSeen == 1 && isRightLeader(lengthA, i, numberMaxKeysRemaining)) {
                    // Console.WriteLine("Leftmost.");
                    numberEquileaders++;
            }
            else if (i == (lengthA - 1) && numberMaxKeysRemaining == 1 && isLeftLeader(lengthA, i, numberMaxKeysSeen)) {
                // Console.WriteLine("Rightmost.");
                numberEquileaders++;
            } else {
                
                if(isLeftLeader(lengthA, i, numberMaxKeysSeen) && isRightLeader(lengthA, i, numberMaxKeysRemaining)) {
                    // Console.WriteLine("Centered.");
                    numberEquileaders++;
                }
                
            }
        }

        return numberEquileaders;
        
    }
    
    private bool isLeader(int size, int numberOccurrences) {
        return (size - numberOccurrences) < numberOccurrences;
    }
    
    private bool isLeftLeader(int arraySize, int index, int numberOccurrences) {
        var l = sizeLeftIncludingIndex(arraySize, index);
        return isLeader(l, numberOccurrences);
    }
    
    private bool isRightLeader(int arraySize, int index, int numberOccurrences) {
        var r = sizeRightExcludingIndex(arraySize, index);
        return isLeader(r, numberOccurrences);
    }
    
    private int sizeLeftIncludingIndex(int totalSize, int index) {
        return index + 1;
    }
    
     private int sizeRightExcludingIndex(int totalSize, int index) {
        return totalSize - (index + 1);    
    }
}