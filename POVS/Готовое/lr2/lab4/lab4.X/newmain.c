/*
 * File:   newmain.c
 */
#define _XTAL_FREQ 1000000
#pragma config WDTE = OFF
#include <pic16f84a.h>
#include <stdlib.h>
#include <stdint.h>
#include <htc.h>

void main()
{
    TRISA = 0xFF;
    TRISB = 0xE0;
    PORTB = 0x00;

    uint8_t press_count = 0;
    uint8_t led_state = 0;
    while(1)
    {
        if(((PORTA & 0x10) == 0x00) && (press_count <= 0x0F)){
            while((PORTA & 0x10) == 0x00);
            press_count++;
            PORTB = press_count;
            led_state ^= 0x10;
            PORTB |= led_state;
        }
    }
}

