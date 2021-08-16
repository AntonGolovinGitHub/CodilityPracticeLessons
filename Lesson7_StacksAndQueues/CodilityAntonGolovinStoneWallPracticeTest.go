// https://app.codility.com/demo/results/trainingBT4B8G-6ZX/

package solution

// you can also use imports, for example:
import "fmt"
// import "os"

// you can write to stdout for debugging purposes, e.g.
// fmt.Println("this is a debug message")

type stack struct {
    heights []int
    pointer int
}

 func (s *stack) Push(height int) {
     if s.pointer < (len(s.heights) - 1) {
        s.pointer = s.pointer + 1;
        // fmt.Println("New pointer value: ", s.pointer);
        s.heights[s.pointer] = height;
     }
    return;
}

func (s *stack) Pop() int {
    if s.pointer >= 0 {
        var tmp int = s.pointer;
        var tmpV int = s.heights[tmp];
        s.pointer = s.pointer - 1;
        // fmt.Println("Now new pointer value: ", s.pointer);
        s.heights[tmp] = 0;
        return tmpV;
    }
    return -1;
}

func (s *stack) Peek(i int) int {
    if (i >= 0) && (i <= s.pointer) {
        // fmt.Println("Peeking at ", s.heights[i]);
        return s.heights[i];
    }
    fmt.Println("Peeking at -1 for some reason");
    return -1;
}

func (s *stack) Index() int {
    return s.pointer;
}

func (s *stack) Pointer() int {
    return s.pointer;
}

func Solution(H []int) int {
    // write your code in Go 1.4
    
    var lenA = len(H);
    
    if(lenA < 1 || lenA > 100000) {
        return 0;
    }
    
    var blocks int = 0;
    
    var s *stack = new(stack);
    
    s.heights = make([]int, lenA);
    s.pointer = -1; // it's always minus one initially
    
    for i := 0; i < lenA; i++ {
        
        // fmt.Println("H[i] = ", H[i]);
        
        if (H[i] < 1) || (H[i] > 1000000000) {
            return 0;
        }
        
        // fmt.Println("Index: ", s.Index());
        // fmt.Println("Pointer: ", s.Pointer());
        // fmt.Println("Peeking: ", s.Peek(s.Index()));
        
        // pop anything greater than H[i] from the stack
        for (s.Index() >= 0) && (s.Peek(s.Index()) > H[i]) {
                // var x int = s.Pop();
                // fmt.Println("Popping ", x);
                s.Pop();
        }
        
        if (s.Index() >= 0) && (s.Peek(s.Index()) == H[i]) {
            continue;
        } else {
            blocks+= 1;
            // fmt.Println("Pushing ", H[i]);
            // fmt.Println("# blocks =  ", blocks);
            s.Push(H[i]);
        }
        
    }
    
    return blocks;
    
}