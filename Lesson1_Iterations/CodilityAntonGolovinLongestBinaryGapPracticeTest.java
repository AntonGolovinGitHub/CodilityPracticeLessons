// https://app.codility.com/demo/results/training5EAAFD-WUJ/

// you can also use imports, for example:
// import java.util.*;

// you can write to stdout for debugging purposes, e.g.
// System.out.println("this is a debug message");

import java.util.*;

class Solution {
    
    public int solution(int N) {
        // write your code in Java SE 8
        
        if(N <= 0)
            return 0;
            
        // for information only, does not matter
        // if(N == Integer.MAX_VALUE) {
        //    System.out.println("[INFO] Found MAX Integer value.");
        // }
        
        String i = Integer.toBinaryString(N);
        
        // System.out.println("Converted " + N + " to " + i);
        
        return longestBinaryGap(i);
        
    }
    
    private int longestBinaryGap(final String s) {
        
        if(s == null)
            return 0;
        
        if(s.length() < 3)
            return 0;
            
        char[] chars = s.toCharArray();
        
        List<Integer> begins = new ArrayList<>();    
        List<Integer> ends = new ArrayList<>();
        List<Integer> counts = new ArrayList<>();
        
        char previous = ' ';
        boolean count = false;
        int counter = 0;
        
        for(int i = 0; i < chars.length; i++) {
        
            if(i == 0 && chars[i] == '0')
                continue;
                
            if(i == (chars.length - 1) && chars[i] == '0')
                continue;
        
            if(i > 0)
                previous = chars[i - 1];
                
            if((previous == '1') && (chars[i] == '0')) {
                begins.add(i);
                count = true;
            }

            if(count)
                counter++;

            if((previous == '0') && (chars[i] == '1')) {
                ends.add(i - 1);
                counts.add(counter - 1);
                count = false;
                counter = 0;
            }
        }
                
        int[] maxBinaryGapCandidates = new int[counts.size()];
        
        for(int j = 0; j < counts.size(); j++) {
            if(isBinaryGap(chars, begins.get(j), ends.get(j)))
                maxBinaryGapCandidates[j] = counts.get(j);
        }
        
        return max(maxBinaryGapCandidates);
        
    }
    
    private boolean isBinaryGap(char[] chars, int begin, int end) {
        
        if(begin == 0)
            return false;
            
        if(end == (chars.length - 1))
            return false;
            
        if((chars[begin - 1] == '1') && (chars[end + 1] == '1'))
            return true;
            
        return false;
    }
    
    private int max(int[] counts) {
    
            if(counts == null)
            return 0;
            
        if(counts.length == 1)
        return counts[0];
        
        
        int currentMax = 0;
        
        for(int i = 0; i < counts.length; i++) {
            if(counts[i] < 0)
                continue;
                
            if(counts[i] > currentMax)
                currentMax = counts[i];
        }
        
        return currentMax;
        
    }
    
}