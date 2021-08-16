// https://app.codility.com/demo/results/trainingUKF4Q7-WQM/

package solution

// you can also use imports, for example:
// import "fmt"
// import "os"
// import "math";
import "sort";

// you can write to stdout for debugging purposes, e.g.
// fmt.Println("this is a debug message")

func Solution(A []int) int {
    // write your code in Go 1.4
    
    var lenA = len(A);
    
    if(lenA > 100000) {
        return 0;
    }
    
    sort.Ints(A);
    
    for i := 0; i < lenA - 2; i++ {
    
        if(((A[i] + A[i+1]) > A[i+2]) && ((A[i+1] + A[i+2]) > A[i]) && ((A[i+2] + A[i]) > A[i+1])) {
                return 1;
            }
    }
    
    return 0;
    
}