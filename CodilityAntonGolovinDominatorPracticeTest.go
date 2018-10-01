// https://app.codility.com/demo/results/trainingVSCSDW-QH4/

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
    
    var lastIndex map[int]int = make(map[int]int);
    var counts map[int]int = make(map[int]int);
    
    for i := 0; i < lenA; i++ {
        
        lastIndex[A[i]] = i;
        
        if _, ok := counts[A[i]]; ok {
            counts[A[i]] = counts[A[i]] + 1;
        } else {
            counts[A[i]] = 1;
        }
        
    }
    
    // find key with max value
    
    var maxValue, maxValueKey int= -1, 0;

    for k, v := range counts {
        if(v > maxValue) {
            maxValue = v;
            maxValueKey = k;
        }        
    }
     
    if (maxValue == -1) {
        return -1;
    }
    
    var noMaxValue int = lenA - maxValue;
    
    // fmt.Println("lenA: ", lenA);
    // fmt.Println("maxValue: ", maxValue);
    // fmt.Println("noMaxValue: ", noMaxValue);
    
    if(maxValue <= noMaxValue) {
        return -1;
    }
    
    var maxValueLastKey = lastIndex[maxValueKey];

    return maxValueLastKey;
    
    
}