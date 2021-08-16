// https://app.codility.com/demo/results/training6DBWTU-SHA/

// you can write to stdout for debugging purposes, e.g.
// printf("this is a debug message\n");

#define MIN 1
#define MAX 100000

int solution(int X, int A[], int N) {
    // write your code in C99 (gcc 6.2.0)
    
    if(N < 1 || N > 100000) {
        return -1;
    }
        
    if(contains(X, A, N) != 1) {
        return -1;
    }
    
    if(N == 1 && A[0] == X)
        return 0;
 
 int *leaves = calloc(sizeof(int), X);   
 int *positions = calloc(sizeof(int), X);
 
 for(int i = 0; i < N; i++) {
     
        if(A[i] <= X) {
        
            leaves[A[i] - 1] = A[i];
        
            // printf("Leaf # %d at slot %d  \r\n", A[i], A[i] - 1);
        
            int pos = (A[i] - 1);
            
            // printf("Pos %d \r\n", pos);
        
            if((i > 0) && (positions[pos] > 0)) {
                // printf("Skipping %d at position %d \r\n", i, pos);
                continue;
            } else {
                positions[pos] = i;
                // printf("Position slot %d of leaf %d \r\n", i, A[i]);
            }

        } else {
            continue;
        }

    }   
 
    if(validate(leaves, X) != 1)
        return -1;
 
     int max_value = max(positions, X);
 
    free(leaves);
    free(positions);
 
    if(max_value == 0) {
        return -1;
    }
    else {
        return max_value;
    }
    
}

int contains(int X, int A[], int N) {

    if(N == 0)
        return 0;
        
    for(int i = 0; i < N; i++) {
        if(A[i] == X) {
            return 1;
        }
    }

 return 0;   
 
}

int validate(int B[], int X) {

    if(B[0] != 1)
        return 0;  

    for(int i = 1; i < X; i++) {
        
        if((B[i] - B[i - 1]) != 1)
        return 0;
    }   
 
    return 1;
}

int max(int B[], int X) {
    
    int max_value = 0;
    
    for(int i = 0; i < X; i++) { 
     
        if(B[i] > max_value) {
            max_value = B[i];
        }
            
    }
    
    return max_value;
       
}