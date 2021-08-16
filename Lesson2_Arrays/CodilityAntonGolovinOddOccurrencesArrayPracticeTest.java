// https://app.codility.com/demo/results/trainingWCYU59-EZF/

// you can also use imports, for example:
import java.util.*;

// you can write to stdout for debugging purposes, e.g.
// System.out.println("this is a debug message");

class Solution {
    public int solution(int[] A) {
        // write your code in Java SE 8
        
        if(A == null)
            return 0;
            
        if(A.length == 0)
            return 0;
            
        if(A.length <= 0 || A.length > 1000000)
            return 0;
            
        Map<Integer, Integer> countingMap = new HashMap<>();
        
        for(int i = 0; i < A.length; i++) {
            if(A[i] <= 0 || A[i] > 1000000000)
                return 0;
                
            if(countingMap.containsKey(A[i]))
                countingMap.remove(A[i]);
            else
                countingMap.put(A[i], A[i]);
        }
        
        Iterator<Integer> it =  countingMap.keySet().iterator();
        
        Integer i = it.next();
        
        if(i == null)
            return 0;
        
        return i;
        
    }
}