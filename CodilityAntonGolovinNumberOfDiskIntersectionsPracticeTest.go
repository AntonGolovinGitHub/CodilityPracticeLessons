// https://app.codility.com/demo/results/trainingH2AM2Z-DDD/package solution

import (
	"container/heap"
	// "fmt"
)

type Point struct {
    location int
    beginning bool
}

// An IntHeap is a min-heap of ints.
type PointHeap []Point

func (h PointHeap) Len() int           { return len(h) }
func (h PointHeap) Less(i, j int) bool { return (h[i].location < h[j].location) || ((h[i].location == h[j].location) && (h[i].beginning == true && h[j].beginning == false))
        // sort dots in correct order as well
     }
func (h PointHeap) Swap(i, j int)      { h[i], h[j] = h[j], h[i] }

func (h *PointHeap) Push(x interface{}) {
	// Push and Pop use pointer receivers because they modify the slice's length,
	// not just its contents.
	*h = append(*h, x.(Point))
}

func (h *PointHeap) Pop() interface{} {
	old := *h
	n := len(old)
	x := old[n-1]
	*h = old[0 : n-1]
	return x
}


func Solution(A []int) int {
 
    var lenA int = len(A);
    
    if(lenA > 100000) {
        return -1;
    }
    
    h := &PointHeap{}
	heap.Init(h)
    
    // transform A into a minheap of points
    
    for i := 0; i < lenA; i++ {
        
        heap.Push(h, Point{i - A[i], true});
        heap.Push(h, Point{i + A[i], false});
        
    }
    
    // fmt.Println(h.Len());
    
    // now, get each value from min heap and check for open circles
    
    var point Point;
    
    var intersections, openCircles int = 0, 0;
    
    for i := 1; i <= lenA * 2; i++ {
        
        point = heap.Pop(h).(Point);
        
        // fmt.Println(point.location);
        // fmt.Println(point.beginning);
        
        if(point.beginning) {
            intersections += openCircles;
            openCircles++;
        } else {
            openCircles--;
        }
        
        if(intersections > 10000000) {
            return -1;
        }
        
    }
    
    return intersections;
    
}