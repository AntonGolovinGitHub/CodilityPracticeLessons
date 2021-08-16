// https://app.codility.com/demo/results/training863XX3-GTD/

package solution

// you can also use imports, for example:
// import "fmt"
import "sort"
// import "os"
// import "math"

// you can write to stdout for debugging purposes, e.g.
// fmt.Println("this is a debug message")

func Solution(A []int) int {
    // write your code in Go 1.4
    
    var lenA = len(A);
    
    if(lenA < 3 || lenA > 100000) {
        return -1;
    }
    
    if(lenA == 3) {
        return A[0]*A[1]*A[2];
    }

    var allNegative, allPositive, mixed bool = true, true, false;
    
    for i := 0; i < lenA; i++ {
        if(A[i] < -1000 || A[i] > 1000) {
            return -1;
        }
        
        if(A[i] >= 0) {
            allNegative = false;
        }
        
        if(A[i] < 0) {
            allPositive = false;
        }
    }
    
    mixed = !allNegative && !allPositive;
    
    sort.Ints(A);
    
    if(allNegative || allPositive) {
        return A[lenA-1]*A[lenA-2]*A[lenA-3];
    }
    
    if(mixed) {
     
     var hasTwoMinimums bool = A[0] < 0 && A[1] < 0;
     var hasThreeMaximums bool = A[lenA - 1] > 0 && A[lenA - 2] > 0 && A[lenA - 3] > 0;
     
     var twoMinimumsOneMaximum = 0;
     var threeMaximums = 0;
     
     if(hasTwoMinimums) {
         twoMinimumsOneMaximum = A[0] * A[1] * A[lenA - 1];
     }
     
     if(hasThreeMaximums) {
        threeMaximums = A[lenA - 1] * A[lenA - 2] * A[lenA - 3];
     }
     
        if(twoMinimumsOneMaximum > threeMaximums) {
            return twoMinimumsOneMaximum;
        }
        
        return threeMaximums;
     
    }
    
    // should never get here
    return -1;   
 
    
}