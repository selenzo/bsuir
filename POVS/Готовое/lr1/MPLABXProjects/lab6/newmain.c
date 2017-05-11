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

void Play(uint8_t data)
{
    switch(data){
        case '1':
            for(uint16_t i = 0; i < 50; i++){
                PORTA |= 0x01;
                __delay_us(1000);
                PORTA &= ~0x01;
                __delay_us(1000);
            }
            break;
        case '2':
            for(uint16_t i = 0; i < 50; i++){
                PORTA |= 0x01;
                __delay_us(900);
                PORTA &= ~0x01;
                __delay_us(900);
            }
            break;
        case '3':
            for(uint16_t i = 0; i < 50; i++){
                PORTA |= 0x01;
                __delay_us(800);
                PORTA &= ~0x01;
                __delay_us(800);
            }
            break;
        case '4':
            for(uint16_t i = 0; i < 50; i++){
                PORTA |= 0x01;
                __delay_us(1000);
                PORTA &= ~0x01;
                __delay_us(1000);
            }
            break;
        case '5':
            for(uint16_t i = 0; i < 50; i++){
                PORTA |= 0x01;
                __delay_us(900);
                PORTA &= ~0x01;
                __delay_us(900);
            }
            break;
        case '6':
            for(uint16_t i = 0; i < 50; i++){
                PORTA |= 0x01;
                __delay_us(800);
                PORTA &= ~0x01;
                __delay_us(800);
            }
            break;
        case '7':
            for(uint16_t i = 0; i < 50; i++){
                PORTA |= 0x01;
                __delay_us(1000);
                PORTA &= ~0x01;
                __delay_us(1000);
            }
            break;
        case '8':
            for(uint16_t i = 0; i < 50; i++){
                PORTA |= 0x01;
                __delay_us(900);
                PORTA &= ~0x01;
                __delay_us(900);
            }
            break;
        case '9':
            for(uint16_t i = 0; i < 50; i++){
                PORTA |= 0x01;
                __delay_us(800);
                PORTA &= ~0x01;
                __delay_us(800);
            }
            break;
        case '0':
            for(uint16_t i = 0; i < 50; i++){
                PORTA |= 0x01;
                __delay_us(900);
                PORTA &= ~0x01;
                __delay_us(900);
            }
            break;
        case '*':
            for(uint16_t i = 0; i < 50; i++){
                PORTA |= 0x01;
                __delay_us(1000);
                PORTA &= ~0x01;
                __delay_us(1000);
            }
            break;
        case '#':
            for(uint16_t i = 0; i < 50; i++){
                PORTA |= 0x01;
                __delay_us(800);
                PORTA &= ~0x01;
                __delay_us(800);
            }
            break;
        default:
            return;
    }
}

uint8_t CaptureKey()
{
    PORTB = 0x04;
    switch(PORTB & 0xF0){
        case 0x10:
            return '1';
        case 0x20:
            return '4';
        case 0x40:
            return '7';
        case 0x80:
            return '*';
    }
    PORTB = 0x02;
    switch(PORTB & 0xF0){
        case 0x10:
            return '2';
        case 0x20:
            return '5';
        case 0x40:
            return '8';
        case 0x80:
            return '8';
    }
    PORTB = 0x01;
    switch(PORTB & 0xF0){
        case 0x10:
            return '3';
        case 0x20:
            return '6';
        case 0x40:
            return '9';
        case 0x80:
            return '#';
    }
    return 0xAA;
}

void main()
{
    TRISA = 0xE0;
    TRISB = 0xF8;
    PORTA = 0x00;
    PORTB = 0x07;

    while(1)
    {
        Play(CaptureKey());
    }
}

