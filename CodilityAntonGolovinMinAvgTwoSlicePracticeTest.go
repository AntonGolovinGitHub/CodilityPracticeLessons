// https://app.codility.com/demo/results/trainingCZAV7J-97C/package solution

// you can also use imports, for example:
// import "fmt"
// import "os"
// import "math"
// import "math/big"

// you can write to stdout for debugging purposes, e.g.
// fmt.Println("this is a debug message")

func Solution(A []int) int {
    // write your code in Go 1.4
    
    var lenA int = len(A);
    
    if(lenA < 2 || lenA > 100000) {
        return -1;
    }
    
    if(lenA == 1) {
        return -1;
    }
    
    if(lenA == 2) {
        return 0;
    }


    var min_position int = 0;    
    var min_division float64 = 10001;
    
   var sumOfTwo float64 = 0;
   var sumOfThree float64 = 0;
   
   
   var divisor_two float64 = 2.0;
   var divisor_three float64 = 3.0;
   
   var division_two float64 = 0;
   var division_three float64 = 0;
   
    for i := 0; i < (lenA - 1); i++ {

        if(A[i] < -10000 || A[i] > 10000) {
            return -1;
        }

        sumOfTwo = float64(A[i] + A[i+1]);

        division_two = sumOfTwo / divisor_two;
        
        if(division_two < min_division) {
            min_division = division_two;
            min_position = i;
        }
        
        if(i < (lenA - 2)) {
            sumOfThree = sumOfTwo + float64(A[i+2]);
            division_three = sumOfThree / divisor_three;    

            if(division_three < min_division) {
                min_division = division_three;
                min_position = i;
            }
        }
      
      
    }    

    return min_position;
    
}