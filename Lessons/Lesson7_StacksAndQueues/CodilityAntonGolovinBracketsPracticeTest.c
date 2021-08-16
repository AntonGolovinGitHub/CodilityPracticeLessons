// https://app.codility.com/demo/results/trainingWT9MRZ-EBP/

// you can write to stdout for debugging purposes, e.g.
// printf("this is a debug message\n");

#define MAXSIZE 200000
#define MAXSIZEMINUSONE 199999

struct stack {
    char chars[MAXSIZE];
    int top;
};

char end_string = '\0';

typedef struct stack STACK;

void push(STACK *s, char c);
char pop(STACK *s);

void push(STACK *s, char c) {
    if(s->top == MAXSIZEMINUSONE)
        return;
    s->chars[s->top] = c;
    s->top++;
}

char pop(STACK* s) {
    if(s->top == 0)
        return end_string;
    s->top--;
    return s->chars[s->top];
}

int solution(char *S) {
    // write your code in C99 (gcc 6.2.0)

    int well_formed = 1;
    
    if(*S == '\0')
        return well_formed;
    
    STACK *s = malloc(sizeof(STACK));
    s->top = 0;
    
    char top_char;

    char curly_open = '{';
    char round_open = '(';
    char square_open = '[';

    while(1) {
    
        switch (*S) {
            case '\0': {
                if(s->top == 0) {
                    well_formed = 1;
                } else {
                    well_formed = 0;
                }
                goto return_statement;
            }
            case '{': {
                if(s->top < MAXSIZEMINUSONE) {
                    push(s, curly_open);    
                    break;
                }
                well_formed = 0;
                goto return_statement;
            }
            case '(': {
                if(s->top < MAXSIZEMINUSONE) {
                    push(s, round_open);    
                    break;
                }
                well_formed = 0;
                goto return_statement;
            }
            case '[': {
                if(s->top < MAXSIZEMINUSONE) {
                    push(s, square_open);    
                    break;
                }
                well_formed = 0;
                goto return_statement;
            }
            case '}': {
                if(s->top > 0) {
                    top_char = pop(s);
                    if(top_char == end_string) {
                        well_formed = 0;                        
                        goto return_statement;       
                    }
                    if(top_char != curly_open) {
                        well_formed = 0;
                        goto return_statement;
                    }
                    break;
                }
                well_formed = 0;
                goto return_statement;
            }
            case ')': {
                if(s->top > 0) {
                    top_char = pop(s);
                    if(top_char == end_string) {
                        well_formed = 0;
                        goto return_statement;       
                    }
                    if(top_char != round_open) {
                        well_formed = 0;
                        goto return_statement;
                    }
                    break;
                }
                well_formed = 0;
                goto return_statement;
            }
            case ']': {
                if(s->top > 0) {
                    top_char = pop(s);
                    if(top_char == end_string) {
                        well_formed = 0;
                        goto return_statement;       
                    }
                    if(top_char != square_open) {
                        well_formed = 0;
                        goto return_statement;
                    }
                    break;
                }
                well_formed = 0;
                goto return_statement;
            }
            default: {
                well_formed = 0;
                goto return_statement;
            }
        }
        
        S++;
        
    }
    
    
    free(s);
    
    return_statement:
    return well_formed;
    
}