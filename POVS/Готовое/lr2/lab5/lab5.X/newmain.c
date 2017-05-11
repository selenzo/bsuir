/*
 * File:   newmain.c
 */
#define _XTAL_FREQ 1000000
#pragma config WDTE = OFF
#include <pic16f84a.h>
#include <stdlib.h>
#include <stdint.h>
#include <htc.h>

#define zero  0b01000000
#define one   0b01111001
#define two   0b00100100
#define three 0b00110000
#define four  0b00011001
#define five  0b01010010
#define six   0b00000010
#define seven 0b01111000
#define eight 0b00000000
#define nine  0b00010000

void DisplayDigit(uint8_t data, uint8_t position)
{
    switch(position){
        case 0:
            PORTA = 0x04;
            break;
        case 1:
            PORTA = 0x08;
            break;
    }
    switch(data){
        case 0:
            PORTB = zero;
            break;
        case 1:
            PORTB = one;
            break;
        case 2:
            PORTB = two;
            break;
        case 3:
            PORTB = three;
            break;
        case 4:
            PORTB = four;
            break;
        case 5:
            PORTB = five;
            break;
        case 6:
            PORTB = six;
            break;
        case 7:
            PORTB = seven;
            break;
        case 8:
            PORTB = eight;
            break;
        case 9:
            PORTB = nine;
            break;
    }
}

void DisplayData(uint16_t data)
{
    DisplayDigit(data%10, 0);
    //__delay_ms(10);
    DisplayDigit(data%10/10, 1);
    //__delay_ms(10);
}

uint8_t AcquireData(void)
{
    uint8_t data = 0;
    PORTA &= ~0x01;
    __delay_ms(10);
    PORTA |= 0x01;
    __delay_ms(10);
    for(uint8_t i = 0; i < 8; i++){
        __delay_ms(40);
        data |= ((PORTA & 0x10) >> 4);
        PORTA |= 0x02;
        __delay_ms(40);
        PORTA &= ~0x02;
        if(i < 7)data <<= 1;
    }
    return data;
}

void main()
{
    TRISA = 0xF0;
    TRISB = 0x00;
    PORTA = 0x01;

    while(1)
    {
        uint8_t temp = AcquireData();
        if(temp & 0x80){
            PORTA &= ~0x08;
            PORTA |= 0x04;
        } else{
            PORTA &= ~0x04;
            PORTA |= 0x08;
        }
        PORTB = ~(temp & 0x7F);
    }
}

