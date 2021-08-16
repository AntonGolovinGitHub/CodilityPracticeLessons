// https://app.codility.com/demo/results/training5EJQ2F-Y45/

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
    
    if(lengthA > 400000)
        return 0;
     
    // check values are right   
    for (var i = 0; i < lengthA; i++) {
        
        if(A[i] > 200000 || A[i] < 0)
            return 0;    
    }
    
    if(lengthA == 1)
        return 0;
        
    if(lengthA == 2)
        return A[1] - A[0];
    
    IList<int> solutions = new List<int>();
    
    solutions.Add(0); // this is the default answer
   
    // look for min and max, if max comes after min, we found the answer,
    // if not, we have three regions to look at
   
   int minIndex = -1, maxIndex = -1;
   
   FindMinMax(A, ref minIndex, ref maxIndex, 0, lengthA);
   
   if(maxIndex > minIndex) {
       return A[maxIndex] - A[minIndex];
   }
    
    if(maxIndex < minIndex) {
       
        int oldMaxIndex = maxIndex;
        int oldMinIndex = minIndex;
       
        FindMinMax(A, ref minIndex, ref maxIndex, 0, oldMaxIndex + 1);    
        
        if(maxIndex > minIndex) {
            solutions.Add(A[maxIndex] - A[minIndex]);
        }
        
        FindMinMax(A, ref minIndex, ref maxIndex, oldMaxIndex + 1, oldMinIndex);    
        
        if(maxIndex > minIndex) {
            solutions.Add(A[maxIndex] - A[minIndex]);
        }
        
        FindMinMax(A, ref minIndex, ref maxIndex, oldMinIndex, lengthA);    
        
        if(maxIndex > minIndex) {
            solutions.Add(A[maxIndex] - A[minIndex]);
        }
       
   }

    return solutions.Max();
   
    }
    
    private void FindMinMax(int[] A, ref int minIndex, ref int maxIndex, int beginIncl, int endExcl) {
        
       int min = int.MaxValue, max = int.MinValue;
   
        for(var i = beginIncl; i < endExcl; i++) {
            
            if(A[i] < min) {
                min = A[i];
                minIndex = i;
            }
            
            if(A[i] > max) {
                max = A[i];
                maxIndex = i;
            }
        }
        
        // Console.WriteLine("Found min index: " + minIndex);
        // Console.WriteLine("Found min value: " + min);
        // Console.WriteLine("Found max index: " + maxIndex);
        // Console.WriteLine("Found max value: " + max);
        // Console.WriteLine("-------");
        
    }   

}