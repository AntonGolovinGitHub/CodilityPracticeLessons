// https://app.codility.com/demo/results/trainingRT7J69-HE3/

package solution

// you can also use imports, for example:
// import "fmt"
// import "os"

// you can write to stdout for debugging purposes, e.g.
// fmt.Println("this is a debug message")

func Solution(A []int) int {
    // write your code in Go 1.4
    
    var lenA = len(A);
    
    if(lenA > 100000) {
        return -1;
    }
    
    var mapA = make(map[int]int);
    
    for i := 0; i < lenA; i++ {
     
        if(A[i] < -1000000 || A[i] > 1000000) {
            return -1;
        }
        
        if _, ok := mapA[A[i]]; ok {
           continue;
        } else {
            mapA[A[i]] = A[i];
        }
    }
    
    return len(mapA);
    
}