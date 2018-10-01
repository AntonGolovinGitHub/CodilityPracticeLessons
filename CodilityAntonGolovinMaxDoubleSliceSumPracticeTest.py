# https://app.codility.com/demo/results/training9CAAMY-FZA/

# from Martin Kysel

def solution(A):
    ending_here = [0] * len(A)
    starting_here = [0] * len(A)
     
    for idx in range(1, len(A)):
        ending_here[idx] = max(0, ending_here[idx-1] + A[idx])
     
    for idx in reversed(range(len(A)-1)):
        starting_here[idx] = max(0, starting_here[idx+1] + A[idx])
     
    max_double_slice = 0
     
    for idx in range(1, len(A)-1):
        max_double_slice = max(max_double_slice, starting_here[idx+1] + ending_here[idx-1])
         
         
    return max_double_slice