// https://app.codility.com/demo/results/trainingQXSVU2-FMA/


// you can also use imports, for example:
// import java.util.*;

// you can write to stdout for debugging purposes, e.g.
// System.out.println("this is a debug message");

class Solution {
    public int[] solution(int[] A, int K) {
        // write your code in Java SE 8
        
        if(A == null)
            return null;
        
        if(A.length == 0)
            return A;
        
        if(A.length > 100)
            return A;
            
        if(K < 0 || K > 100)
            return A;
    
        int[] oldA = A;
        int[] newA = null; 
        
        for(int i = 0; i < K; i++) {
            newA = new int[oldA.length];
            int shift = oldA[oldA.length - 1];
            System.arraycopy(oldA, 0, newA, 1, oldA.length - 1);
            newA[0] = shift;
            oldA = newA;
            
        }
        
        return oldA;
    }
    
    
}
