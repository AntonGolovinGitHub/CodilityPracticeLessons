//  https://app.codility.com/demo/results/trainingFJS57C-JBJ/

// reworked in C# from Martin Kysel's solution

using System;
using System.Collections.Generic;
using System.Linq;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int[] solution(int N, int[] P, int[] Q) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        
        if(P == null)
            return null;
            
        if(Q == null)
            return null;
        
        if(N < 1 || N > 50000)
            return null;
            
        var lengthP = P.Length;
        var lengthQ = Q.Length;
        
        if(lengthP != lengthQ)
            return null;
            
        if(lengthP < 1 || lengthP > 30000)
            return null;
        
        int maxQ = 0;
        
        for(var t = 0; t < lengthQ; t++) {
            if(P[t] < 1 || Q[t] > 50000)
                return null;
            if(Q[t] > maxQ)
                maxQ = Q[t];
        }        
        
        // get all primes, then semi-primes up to N
                
        var notPrimes = new bool[N + 1];
        
        notPrimes[0] = notPrimes[1] = true;
        
        var i = 2;
        
        while (i*i <= N) {
            if(notPrimes[i] == false) {
                for(var j = i*i; j < N+1; j+=i ) {
                    notPrimes[j] = true;
                }
            }
            i++;
        }
        
        var semiPrimes = new HashSet<int>();
        
        int k = 2;

        while(k*k <= N) {
            if(notPrimes[k] == false) {
                for(var z = k*k; z < N+1; z+= k) {
                    if(z % k == 0 && notPrimes[z / k] == false)
                        semiPrimes.Add(z);
                }
            }
            k++;    
        }        
        
        var counts = new List<int>();
        
        counts.Add(0); // 0 semi-primes for value 0
        counts.Add(0); // 0 semi-primes for value 1
        counts.Add(0); // 0 semi-primes for value 2
        counts.Add(0); // 0 semi-primes for value 3
        counts.Add(1); // 1 semi-prime for value 4 (4 is a semi-prime)
        
        for(var q = 5; q <= maxQ; q++) {
            if(semiPrimes.Contains(q))
                counts.Add(counts[q-1]+1);
            else
                counts.Add(counts[q-1]);
        }
        
        var results = new int[lengthQ];
        
         for(var x = 0; x < lengthQ; x++) {
            results[x] = (counts[Q[x]] - counts[P[x] - 1]);
         }
        
        return results;
        

    }
    
    
}