// https://app.codility.com/demo/results/trainingBCV34N-4QR/

// you can write to stdout for debugging purposes, e.g.
// printf("this is a debug message\n");

#define DEBUG 0

int solution(int A[], int B[], int N) {
    // write your code in C99 (gcc 6.2.0)
    
    if(N < 1 || N > 100000)
        return -1;

    if(N == 1) { 
        
        if(A[0] < 0 || A[0] > 1000000000) {
            return -1;
        }
        
        return 1;
    }

    if(N == 2) {
        
        if(A[0] < 0 || A[0] > 1000000000) {
            return -1;
        }
        
        if(A[1] < 0 || A[1] > 1000000000) {
            return -1;
        }
        
        if(B[0] == 1 && B[1] == 0) {
            return 1;
        }
        
        if(B[0] == 0 && B[1] == 1) {
            return 2;
        }
        
        return 2;
    }
    
   int eaten_fish = 0;
   
    for (int i = 0; i < N; i++) {
        
        if(B[i] != 0 && B[i] != 1) {
            return -1;
        }

        if((A[i] < 0) || (A[i] > 1000000000)) {
            return -1;
        }

    }
  
    while(1) {
   
    int fish_eating_this_cycle = 0;
   
    // eat all fish swimming upstream
    for (int i = 0; i < N-1; i++) {

        // skip over fish swimming upstream
        if(B[i] == 0) {
            continue;
        }
       
       // pass a fish that was already eaten
       if(A[i+1] == -1) {
           int bTmp = B[i+1];
           B[i+1] = B[i];
           B[i] = bTmp;
           int aTmp = A[i+1];
           A[i+1] = A[i];
           A[i] = aTmp;
           continue;
       }
       
       if(B[i] == 1 && B[i+1] == 1) {
           continue;
       }
       
       if(B[i] == 1 && B[i+1] == 0) {
           if(A[i] > A[i+1]) {
                fish_eating_this_cycle++;
                A[i+1] = -1;
                int bTmp = B[i+1];
                B[i+1] = B[i];
                B[i] = bTmp;
                int aTmp = A[i+1];
                A[i+1] = A[i];
                A[i] = aTmp;
           } else {
               continue;
           }
       }

    }
    
    // eat all fish swimming upstream
    for (int i = N-1; i >= 1; i--) {
        
         // skip over fish swimming downstream
        if(B[i] == 1) {
            continue;
        }
       
       // pass a fish that was already eaten
       if(A[i-1] == -1) {
           int bTmp = B[i-1];
           B[i-1] = B[i];
           B[i] = bTmp;
           int aTmp = A[i-1];
           A[i-1] = A[i];
           A[i] = aTmp;
           continue;
       }
       
       if(B[i] == 0 && B[i-1] == 0) {
           continue;
       }
       
       if(B[i] == 0 && B[i-1] == 1) {
           if(A[i] > A[i-1]) {
                fish_eating_this_cycle++;
                A[i-1] = -1;
                int bTmp = B[i-1];
                B[i-1] = B[i];
                B[i] = bTmp;
                int aTmp = A[i-1];
                A[i-1] = A[i];
                A[i] = aTmp;
           } else {
               continue;
           }
       }        
    
    }
    
    if(fish_eating_this_cycle == 0)
        break;
        
    eaten_fish += fish_eating_this_cycle;
    
    }

    return (N - eaten_fish);
    
}