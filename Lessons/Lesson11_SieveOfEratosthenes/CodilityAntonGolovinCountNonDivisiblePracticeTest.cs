//  https://app.codility.com/demo/results/trainingSW9AWQ-G37/

// reworked in C# from Martin Kysel's solution

using System;
using System.Collections.Generic;
using System.Linq;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    
    
    private static int MIN = 1;
    private static int MAX = 100000;
    
    public int[] solution(int[] A) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        
        if(A == null)
            return null;
        
        var lengthA = A.Length;
        
        if(lengthA < 1 || lengthA > 50000)
            return null;
        
        var counters = new Dictionary<int, int>();
        var divisors = new Dictionary<int, ISet<int>>();
        var maxA = MIN;
        
        // populate all details and find max
        foreach(var element in A) {
            if(element < MIN || element > MAX)    
                return null;
            if(counters.ContainsKey(element))
                counters[element] += 1;
            else
                counters[element] = 1;
            divisors[element] = new HashSet<int>();
            divisors[element].Add(1);
            divisors[element].Add(element);
            if(element > maxA)
                maxA = element;
        }
     
     var divisor = 2;
     
     while (divisor * divisor <= maxA) {
         var element_candidate = divisor;
         while (element_candidate <= maxA) {
             if(divisors.ContainsKey(element_candidate) && !(divisors[element_candidate].Contains(divisor))) {
                 divisors[element_candidate].Add(divisor);
                 divisors[element_candidate].Add(element_candidate / divisor);
             }
            element_candidate += divisor;
         }
         divisor++;
     }
     
     var result = new int[lengthA];
     
     for(var i = 0; i < lengthA; i++) {
         var allDivisors = AllDivisors(A[i], counters, divisors);
         var nonDivisors = lengthA - allDivisors;
         result[i] = nonDivisors;
     }
     
     return result;   
        
    }
    
    
    private int AllDivisors(int element, IDictionary<int, int> counters, IDictionary<int, ISet<int>> divisors) {
        
        int sumCounts = 0;

        foreach(var divisor in divisors[element]) {
            sumCounts += (counters.ContainsKey(divisor) ? counters[divisor] : 0);
        }
    
        return sumCounts;
        
    }
    
}