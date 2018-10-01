// https://app.codility.com/demo/results/training9UVD96-C8K/

// you can use includes, for example:
// #include <algorithm>
#include <set>

// you can write to stdout for debugging purposes, e.g.
// cout << "this is a debug message" << endl;

int solution(vector<int> &A) {
    // write your code in C++14 (g++ 6.2.0)
    
    if(A.size() < 1 && A.size() > 100000)
        return 0;
        
    for(int i = 0; i < A.size(); i++) {
        int a = A.at(i);
        if(a < 1 || a > 1000000000)
            return 0;
    }
    
    set<int> *s = new set<int>();
    
    int v_size = A.size();
    
    for(int i = 0; i < v_size; i++) {
        s->insert(A.at(i));
    }
    
    // check uniqueness
    if(s->size() != A.size())
        return 0;
    
    int previous, current;

    int counter = 0;

    set<int>::iterator iter = s->begin();

    while(iter != s->end()) {

        int v = *iter;

        // cout << "Found: " << v  << "\r\n";

        if(counter++ == 0) {
        
            previous = v;
            
            if(previous != 1)
                return 0;
        }
            
        else {
            
            current = v;

            if((current - previous) == 0) {
                continue;
            }


            if((current - previous) != 1) {
                return 0;
            }
             
            // cout << "Found: " << current << "\r\n";
            
            previous = current;

        }


        
        iter++;
            
    }
        
    delete s;
    
    return 1;
}