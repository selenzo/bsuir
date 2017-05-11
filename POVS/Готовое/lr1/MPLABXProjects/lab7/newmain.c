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
#include <stdbool.h>



void main()
{

    TRISA = 0xFE;
    TRISB = 0xFF;
    PORTA = 0x01;

    bool led_enabled = false;
    while(1)
    {
        if((PORTB & 0x01) == 0x00){
            while((PORTB & 0x01) == 0x00);
            led_enabled ^= true;
        }
        if((PORTB & 0x02) == 0x00){
            while((PORTB & 0x02) == 0x00);
            led_enabled ^= true;
        }
        if(led_enabled) PORTA = 0x00;
        else PORTA = 0x01;
    }
}

