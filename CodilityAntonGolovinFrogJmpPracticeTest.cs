// https://app.codility.com/demo/results/trainingZRCUGV-3AW/

using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int solution(int X, int Y, int D) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        
        if(X <= 0 && X > 1000000000)
            return 0;
            
        if(Y <= 0 && Y > 1000000000)
            return 0;
            
        if(D <= 0 && D > 1000000000)
            return 0;
            
        if(X > Y)
            return 0;
            
        int Z = Y - X;
        
        int L = Z % D;
        
        int K = Z / D;
        
        if(L == 0)
            return K;
        else
            return K + 1;
        
        
    }
}