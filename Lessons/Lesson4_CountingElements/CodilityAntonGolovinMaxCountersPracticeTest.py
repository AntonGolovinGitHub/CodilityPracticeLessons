# https://app.codility.com/demo/results/trainingBJYQU6-K75/

# you can write to stdout for debugging purposes, e.g.
# print("this is a debug message")

import array

def solution(N, A):
    # write your code in Python 3.6
             
    if((N < 1) or (N > 100000)):
        return None
    
    aLength = len(A)
    
    if(aLength < 1 or aLength > 100000):
        return None
    
    counterList = [0] * N
    
    nPlusOne = N + 1
    aIMinusOne = None
    max = 0
    maxCounterOnly = True

    intArray = array.array('i', A)


    for nVal in intArray:
        if((nVal < 1) or (nVal > nPlusOne)):
            return None
        if(nVal <= N):
            aIMinusOne = nVal - 1
            counterList[aIMinusOne] = counterList[aIMinusOne] + 1
            if(counterList[aIMinusOne] > max):
                max = counterList[aIMinusOne]
            maxCounterOnly = False
        elif(nVal == nPlusOne):
            if(maxCounterOnly == True):
                continue;            
            else:
                counterListLen = len(counterList)
                counterList = [max] * counterListLen
        else:
            continue
    
    if(maxCounterOnly == True):
        return [max] * N
    else:
        return counterList