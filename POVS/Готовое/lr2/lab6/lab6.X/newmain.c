/*
 * File:   newmain.c
 */
#define _XTAL_FREQ 1000000
#pragma config WDTE = OFF
#include <pic16f84a.h>
#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <string.h>
#include <stdbool.h>
#include <htc.h>


uint8_t CaptureKey()
{
    PORTB = 0x04;
    switch(PORTB & 0xF0){
        case 0x10:
            //while((PORTB & 0x10) == 0x10);
            return 0x01;
        case 0x20:
            //while((PORTB & 0x20) == 0x20);
            return 0x04;
        case 0x40:
            //while((PORTB & 0x40) == 0x40);
            return 0x07;
        case 0x80:
            //while((PORTB & 0x80) == 0x80);
            return 0x00;
    }
    PORTB = 0x02;
    switch(PORTB & 0xF0){
        case 0x10:
            //while((PORTB & 0x10) == 0x10);
            return 2;
        case 0x20:
            //while((PORTB & 0x20) == 0x20);
            return 5;
        case 0x40:
            //while((PORTB & 0x40) == 0x40);
            return 8;
        case 0x80:
            //while((PORTB & 0x80) == 0x80);
            return 0;
    }
    PORTB = 0x01;
    switch(PORTB & 0xF0){
        case 0x10:
            //while((PORTB & 0x10) == 0x10);
            return 3;
        case 0x20:
            //while((PORTB & 0x20) == 0x20);
            return 6;
        case 0x40:
            //while((PORTB & 0x40) == 0x40);
            return 9;
        case 0x80:
            //while((PORTB & 0x80) == 0x80);
            return 0;
    }
    return 0xAA;
}

void main()
{
    TRISA = 0xF0;
    TRISB = 0xF8;
    PORTA = 0x00;
    PORTB = 0x07;

    uint8_t temp,porta = 0;
    while(1)
    {
        temp = CaptureKey();
        if (temp == 0xAA) temp = porta;
        if (porta != temp){
            porta = temp;
            PORTA = porta;
        }
    }
}

