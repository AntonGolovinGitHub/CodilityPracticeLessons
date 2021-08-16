// https://app.codility.com/demo/results/trainingXEC4G6-HW5/



// you can write to stdout for debugging purposes, e.g.
// printf("this is a debug message\n");

int solution(char *S) {
    // write your code in C99 (gcc 6.2.0)
    
    
    int counter = 0;
    int open = 0;
    int closed = 0;
    
    char last;
    
    int first_pass = 1;
    
    while(*S != '\0') {

        if(first_pass) {
            if((*S == ')'))
                return 0;
            first_pass = 0;
        }

        last = *S;
        
        if(counter < 0) 
            return 0;

        if(counter == 0 && (open != closed))
            return 0;
            
        if((*S == '\0' && counter <= 0) && last == '(')
            return 0;
            
        if((*S == '\0' && counter > 0) && last == ')')
            return 0;

        if(*S == '(') {
            open++;
            counter++;
        }
        if(*S == ')') {
            closed++;
            counter--;
        }
        if(*S != '(' && *S != ')') {
            return 0;
        }
            
        S++;
    }
    
    return counter == 0 ? 1 : 0;
}
