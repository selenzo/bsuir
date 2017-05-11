/*
 * File:   newmain.c
 */

#define _XTAL_FREQ 1000000

#include <pic16f84a.h>
#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <htc.h>
#include <stdbool.h>
#pragma config WDTE = OFF
#define ALL_TOGETHER
//#define ONLY_ONE
//#define TWO_FROM_FOUR
#define BINARY
/*
 *
 */
void main()
{
    TRISB = 0xF0;
    TRISA = 0xF0;

    PORTB = 0x00;

    while(1)
    {

        PORTA = 0x02;

        #ifdef ALL_TOGETHER
        PORTB = 0x0F;
        __delay_ms(1000);
        PORTB = 0x00;
        __delay_ms(1000);
        #endif
        #ifdef ONLY_ONE
        PORTB = 0x01;
        __delay_ms(1000);
        PORTB = 0x02;
        __delay_ms(1000);
        PORTB = 0x04;
        __delay_ms(1000);
        PORTB = 0x08;
        __delay_ms(1000);
        #endif
        #ifdef TWO_FROM_FOUR
        PORTB = 0x0C;
        __delay_ms(1000);
        PORTB = 0x0A;
        __delay_ms(1000);
        PORTB = 0x09;
        __delay_ms(1000);
        PORTB = 0x06;
        __delay_ms(1000);
        PORTB = 0x05;
        __delay_ms(1000);
        PORTB = 0x03;
        __delay_ms(1000);
        PORTB = 0x09;
        __delay_ms(1000);
        #endif
        #ifdef BINARY
        PORTB = 0x01;
        __delay_ms(1000);
        PORTB = 0x02;
        __delay_ms(1000);
        PORTB = 0x03;
        __delay_ms(1000);
        PORTB = 0x04;
        __delay_ms(1000);
        PORTB = 0x05;
        __delay_ms(1000);
        PORTB = 0x06;
        __delay_ms(1000);
        PORTB = 0x07;
        __delay_ms(1000);
        PORTB = 0x08;
        __delay_ms(1000);
        PORTB = 0x09;
        __delay_ms(1000);
        PORTB = 0x0A;
        __delay_ms(1000);
        PORTB = 0x0B;
        __delay_ms(1000);
        PORTB = 0x0C;
        __delay_ms(1000);
        PORTB = 0x0D;
        __delay_ms(1000);
        PORTB = 0x0F;
        __delay_ms(1000);
        #endif
    }
}

