/*
 * File:   newmain.c

 */
#define _XTAL_FREQ 1000000
#pragma config WDTE = OFF
#include <pic16f84a.h>
#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <htc.h>


void main()
{
    TRISA = 0xE0;
    TRISB = 0x00;
    while(1)
    {
        PORTA = 0x01;
        PORTB = 0x30;
        __delay_ms(1000);
        PORTA |= 0x02;
        PORTB = 0x60;
        __delay_ms(500);
        PORTB |= 0x10;
        __delay_ms(500);
        PORTB &= ~0x10;
        __delay_ms(500);
        PORTB |= 0x10;
        __delay_ms(500);
        PORTB &= ~0x10;
        __delay_ms(500);
        PORTB |= 0x08;
        __delay_ms(500);
        PORTA = 0x04;
        PORTB = 0x84;
        __delay_ms(1000);
        PORTB = 0x0C;
        PORTA = 0x00;
        __delay_ms(500);
        PORTA |= 0x04;
        PORTB |= 0x80;
        __delay_ms(500);
        PORTA &= ~0x04;
        PORTB &= ~0x80;
        __delay_ms(500);
        PORTA |= 0x04;
        PORTB |= 0x80;
        __delay_ms(500);
        PORTA &= ~0x04;
        PORTB &= ~0x80;
        __delay_ms(500);
        PORTA |= 0x02;
        PORTB |= 0x40;
        __delay_ms(500);
    }
}

