// https://app.codility.com/demo/results/trainingRBGU5V-4U8/

package solution

// you can also use imports, for example:
// import "fmt"
// import "os"

// you can write to stdout for debugging purposes, e.g.
// fmt.Println("this is a debug message")

func Solution(A []int) int {
    // write your code in Go 1.4
    
    if(len(A) < 1 || len(A) > 100000) {
        return -1;
    }
    
    if(len(A) == 0) {
        return 0;
    }
    
    if(len(A) == 1) {
        if(A[0] != 0 && A[0] != 1) {
            return -1;
        }
        return 0;
    }
    
    if(len(A) == 2) {
        
        if(A[0] != 0 && A[0] != 1) {
            return -1;
        }
        
        if(A[1] != 0 && A[1] != 1) {
            return -1;
        }
        
        if(A[0] == 0 && A[1] == 1) {
            return 1;
        }
        if(A[0] == 1 && A[1] == 0) {
            return 0;
        }
        
        return 0;
    }
 
    
    var index int = FindFirstEastboundValueIndex(A, 0);
    
    if(index == -1) {
        return 0;
    }
    
    if(index == (len(A) - 1)) {
        return 0;
    }
    
    var value int = A[index];
    var left_sum int = 0;
    
    var passes int;

    for i:= (index + 1); i < len(A); i++ {
        
        if(value == 0) {
            if(A[i] == 1) {
                left_sum++;   
            }
            continue;
        }

    }

    passes = left_sum;

    for i:= 0; i < len(A); i++ {
    
        if(i == 0) {
            value = A[0];
            // latest_value_position = 0;
            continue;
        }
        
        if(value == 0) {
            
            if(A[i] == 1) {
                left_sum = left_sum - 1;
            }

        } else {
            return -1;
        }
        
        if(A[i] == value) {
            passes += left_sum;
        }
        
        if(passes > 1000000000) {
            return -1;
        }

    }
    
   return passes;    
    
}

func FindFirstEastboundValueIndex(A []int, value int) int {
    
    for i:= 0; i < len(A); i++ {
        if(A[i] == value) {
            return i;
        }
    }
    
    return - 1;
    
}