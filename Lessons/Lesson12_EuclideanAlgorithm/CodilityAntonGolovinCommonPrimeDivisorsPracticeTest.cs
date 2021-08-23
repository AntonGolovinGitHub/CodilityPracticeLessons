//  https://app.codility.com/demo/results/training8PMRK7-8G5/

// reworked in C# from Martin Kysel's solution

using System;
using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int solution(int[] A, int[] B) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        
        if(A == null)
            return -1;
        
        if(B == null)
            return -1;
        
        var lengthA = A.Length;    
        var lengthB = B.Length;
        
        if(lengthA != lengthB)
            return -1;
            
        if(lengthA < 1 || lengthA > 6000)
            return -1;
            
        int counter = 0;
        
        for(int i = 0; i < lengthA; i++) {
            if(A[i] < 1 || B[i] < 1)
                return -1;
            if(HasSameFactors(B[i], A[i]))
                counter++;
        }
        
        return counter;
    }
    
      private long GreatestCommonDivider(long N, long M) {
        if (M == 0)
            return N;
        return GreatestCommonDivider(M, N % M);
    }
    
    private bool HasSameFactors(long N, long M) {
        if(N == M)
            return true;
            
        var gcd = GreatestCommonDivider(N, M);
        
        
        while(N != 1) {
            var N_gcd = GreatestCommonDivider(N, gcd);
            if(N_gcd == 1)
                break;
            N  /= N_gcd;
        }
        
        while(M != 1) {
            var M_gcd = GreatestCommonDivider(M, gcd);
            if(M_gcd == 1)
                break;
            M /= M_gcd;
        }
        
        // if both values can be reduced to 1, they have common prime dividers
        if(N == 1 && M == 1)
            return true;
        
        return false;
        
    }
    
}