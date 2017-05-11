/*
 * File:   newmain.c

 */
#define _XTAL_FREQ 1000000

#include <xc.h>
#include <pic16f84a.h>
#pragma config WDTE = OFF
#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <stdbool.h>

uint8_t digits[10] = {
      0b10000000  //zero
    , 0b11110010  //one
    , 0b01001000  //two
    , 0b01100000  //three
    , 0b00110010  //four
    , 0b00100100  //five
    , 0b00000100  //six
    , 0b11110000  //seven
    , 0b00000000  //eight
    , 0b00100000  //nine
};


void DisplayDigit(uint8_t data, uint8_t position)
{
    PORTA = 1<<position;
    PORTB = digits[data];
}

void DisplayData(uint16_t data)
{
    DisplayDigit(data%10, 0);
//    __delay_ms(5);
    DisplayDigit((data/10)%10, 1);
//    __delay_ms(5);
    DisplayDigit((data/100)%10, 2);
//    __delay_ms(5);
    DisplayDigit(data/1000, 3);
//    __delay_ms(5);
}

volatile uint16_t sub_seconds;
volatile uint16_t seconds;
volatile bool enabled;

void interrupt isr()
{
    if (INTF){
        enabled = ~enabled;
        if (enabled)
        {
            seconds = 0;
            sub_seconds = 0;
        }
        INTF = 0;
    }
    if (T0IF){
        sub_seconds++;
        T0IF =0;
    }
}


void main()
{

    TMR0 = 58;
    T0CS = 0x00;
    T0SE = 0x00;
    PSA = 0x00;
    PS0 = 0x01;
    PS1 = 0x00;
    PS2 = 0x01;
//

    TRISA = 0xF0;
    TRISB = 0x01;
    PORTA = 0x0F;
    PORTB = digits[0];
//
    GIE = 0;
    INTEDG = 0;
    INTE = 1;
    T0IE = 1;
    GIE =1;

    seconds = 0;
    sub_seconds =0;
    while(1)
    {
        if (enabled)
            if(sub_seconds == 10){
                seconds++;
                sub_seconds =0;
            }
        DisplayData(seconds);
    }
}

