# https://app.codility.com/demo/results/trainingENANHV-8FE/

# you can write to stdout for debugging purposes, e.g.
# print("this is a debug message")

def solution(A):
    # write your code in Python 3.6

    lengthA = len(A)
    
    if(lengthA < 1 or lengthA > 100000):
        return None

    result = 1
    
    dict_A = dict()
    
    for i in A:
        
        if(i < -1000000 or i > 1000000):
            return 1
    
        if(i <= 0):
            continue
        
        dict_A[i] = i
    
    keys = sorted(dict_A.keys())
    
    if(len(keys) == 0):
        result = 1
        return result
    
    if(len(keys) == 1):
        if(keys[0] != 1):
            result = 1
            return result
        result = keys[0]+ 1
        return result
        
    previous_key = -1
    current_key = -1
    counter = 0
    
    foundResult = -1
    max = 0
    min = 1000000
    
    for i in keys:
    
        if(max < i):
            max = i
            
        if(min > i):
            min = i
        
        if(counter == 0):
            counter = counter + 1
            current_key = i
            continue
        
        previous_key = current_key
        current_key = i
        
        difference = current_key - previous_key
        
        if((difference) > 1):
            foundResult = previous_key + 1
            break
        
        counter = counter + 1
    
    if(min > 1):
        return 1
    
    if(foundResult == -1):
        return max + 1
    
    result = foundResult
    
    return result