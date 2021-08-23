// https://app.codility.com/demo/results/trainingUZMBVD-JDQ/

// reworked in C# from Martin Kysel's solution

using System;
using System.Collections.Generic;
using System.Linq;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int solution(int N, int M) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        
        if(N < 1 || N > 1000000000)    
            return -1;
            
        if(M < 1 || M > 1000000000)    
            return -1;
            
        return (int)(LeastCommonMultiplier(N, M) / M);
        
    }
    
    private long GreatestCommonDivider(long N, long M) {
        if (M == 0)
            return N;
        return GreatestCommonDivider(M, N % M);
    }
    
    private long LeastCommonMultiplier(long N, long M) {
        return N * (M / GreatestCommonDivider(N, M));
    }
    
}