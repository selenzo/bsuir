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

#define zero  PORTA = 0b00000000;\
              PORTB &= 0b11111100;\
              PORTB |= 0b00000010;
#define one   PORTA = 0b00011001;\
              PORTB &= 0b11111100;\
              PORTB |= 0b00000011;
#define two   PORTA = 0b00000100;\
              PORTB &= 0b11111100;\
              PORTB |= 0b00000001;
#define three PORTA = 0b00010000;\
              PORTB &= 0b11111100;\
              PORTB |= 0b00000001;
#define four  PORTA = 0b00011001;\
              PORTB &= 0b11111100;\
              PORTB |= 0b00000000;
#define five  PORTA = 0b00010010;\
              PORTB &= 0b11111100;\
              PORTB |= 0b00000000;
#define six   PORTA = 0b00000010;\
              PORTB &= 0b11111100;\
              PORTB |= 0b00000000;
#define seven PORTA = 0b00011000;\
              PORTB &= 0b11111100;\
              PORTB |= 0b00000011;
#define eight PORTA = 0b00000000;\
              PORTB &= 0b11111100;\
              PORTB |= 0b00000000;
#define nine  PORTA = 0b00010000;\
              PORTB &= 0b11111100;\
              PORTB |= 0b00000000;


void DisplayDigit(uint8_t data, uint8_t position)
{

    PORTB &= 0x03;
    switch(position){
        case 0:
            PORTB |= 0x80;
            break;
        case 1:
            PORTB |= 0x40;
            break;
        case 2:
            PORTB |= 0x20;
            break;
        case 3:
            PORTB |= 0x10;
            break;
        case 4:
            PORTB |= 0x08;
            break;
        case 5:
            PORTB |= 0x04;
            break;
    }
    switch(data){
        case 0:
            zero;
            break;
        case 1:
            one;
            break;
        case 2:
            two;
            break;
        case 3:
            three;
            break;
        case 4:
            four;
            break;
        case 5:
            five;
            break;
        case 6:
            six;
            break;
        case 7:
            seven;
            break;
        case 8:
            eight;
            break;
        case 9:
            nine;
            break;
    }

}

volatile uint16_t sub_seconds;

void interrupt isr()
{
    if (T0IF){
        sub_seconds++;
        T0IF =0;
    }
}

void DisplayHours(uint8_t data)
{
    DisplayDigit(data % 10, 4);
    DisplayDigit(data / 10, 5);
}

void DisplayMins(uint8_t data)
{
    DisplayDigit(data % 10, 2);
    DisplayDigit(data / 10, 3);
}

void DisplaySec(uint8_t data)
{
    DisplayDigit(data % 10, 0);
    DisplayDigit(data / 10, 1);
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

    GIE = 0;
    T0IE = 1;
    GIE =1;

    TRISA = 0xE0;
    TRISB = 0x00;
    uint8_t hours =19, min=05, sec =43;

    sub_seconds =0;
    while(1)
    {
        if (sub_seconds >= 10){
            sec++;
            sub_seconds =0;
        }

        if (sec>=60)
        {
            sec = 0;
            min++;
        }
        if (min >=  60)
        {
            min = 0;
            hours++;
        }
        if (hours >= 24)
            hours = 0;

        DisplayHours(hours);
        DisplayMins(min);
        DisplaySec(sec);
    }
}

