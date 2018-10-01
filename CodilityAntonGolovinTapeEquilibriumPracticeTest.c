// https://app.codility.com/demo/results/trainingZ4QD6P-8SA/



// you can write to stdout for debugging purposes, e.g.
// printf("this is a debug message\n");

#define MIN -1000
#define MAX 1000

int solution(int A[], int N) {
    // write your code in C99 (gcc 6.2.0)
    
    if(N < 2 || N > 100000)
        return 0;
        
    if(verify_input(A, N, MIN, MAX) != 1)
        return 0;
    
    int *sumsLeft = calloc(sizeof(int), (N - 1));
    int *sumsRight = calloc(sizeof(int), (N - 1));
    int *differences = calloc(sizeof(int), (N - 1));

    sum_left(A, N, sumsLeft);
    sum_right(A, N, sumsRight);
    difference(sumsLeft, sumsRight, N - 1, differences);

    int answer = min_value(differences, N - 1);
    
    free(sumsLeft);
    free (sumsRight);
    free (differences);
    
    return answer;
}

// |0|1|2|3|4| N = 5
    // |0|1|2|3| V = 4

void sum_left(int* A, int N, int* sumsLeft) {

    int *previous = NULL;

    for(int i = 0; i < N; i++) {

            if(i == 0) {
                previous = &A[i];
                *sumsLeft = A[i];
            }
            else if(i == (N - 1)) {
                continue;
            }
            else {
                *sumsLeft = *previous + A[i];
                previous = sumsLeft;
            }
            
            // printf("Found overall from left %d \r\n", *sumsLeft);
            sumsLeft++;
             
    }   
}

void sum_right(int* A, int N, int* sumsRight) {

    int *previous = NULL;

    // |0|1|2|3|4| N = 5
    // |0|1|2|3|  V = 4

    for(int i = 0; i < (N - 2); i++) {
        sumsRight++;        
    }

    for(int i = (N - 1); i >= 0; i--) {

            if(i == (N - 1)) {
                previous = &A[i];
                *sumsRight = A[i];
            }
            else if(i == 0) {
                continue;
            }
            else {
                *sumsRight = *previous + A[i];
                previous = sumsRight;
             
            }
            
               // printf("Found overall from right %d \r\n", *sumsRight);
                sumsRight--;

    }
}

void difference(int *A, int *B, int N, int *C) {
    for(int i = 0; i < N; i++) {
        C[i] = abs(A[i] - B[i]);
        // printf("Found overall from difference %d \r\n", C[i]);
    }   
}
    
int min_value(int* A, int N) {
    
    int minNew = abs(MIN) + abs(MAX);
    
    for(int i = 0; i < N; i++) {
        if(A[i] < minNew) {
            minNew = A[i];
        }
    }
    
    return minNew;
    
}

int verify_input(int *A, int N, int min, int max) {
    
    for(int i = 0; i < N; i++) {
        if(A[i] < min || A[i] > max)
            return 0;
    }
    
    return 1;
       
}
