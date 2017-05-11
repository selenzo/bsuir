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

uint8_t pow2(uint8_t n) {
  return 1<<n;
}

volatile uint8_t code=0;
volatile uint8_t type =0;

uint8_t generateCode1(){
    code++;
    if (code > 0b1111)
        code = 0;
    return code;
}
uint8_t generateCode2()
{
    if (code == 0)
        code = 0b10000;
    code--;
    return code;
}
uint8_t generateCode3(){
    code++;
    if (code == 16)
        code = 0;
    return code^(code>>1);
}
uint8_t generateCode4(){
    uint8_t res = (1<<code);
    code++;
    if (code>3)
        code=0;

    return res;
}
uint8_t generateCode5(){
    if (code&0b1000)
        code = code<<1;
    else
        code = (code<<1 )+1;
    return code;
}

void PlaySequence(uint8_t data)
{
    switch(data){
        case '1':
            PORTA = generateCode1();
            break;
        case '2':
             PORTA = generateCode2();
            break;
        case '3':
             PORTA = generateCode3();
            break;
        case '5':
            PORTA = generateCode4();
            break;
        case '6':
             PORTA = generateCode5();
            break;
        default:
            PORTA =0;
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
            return '0';
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
    uint8_t temp_btn;
    while(1)
    {
        for (uint8_t i =0; i<10; i++){
            temp_btn = CaptureKey();
//             __delay_ms(100);
            if (0xAA == temp_btn)
                continue;
            if (temp_btn != type){
                type = temp_btn;
                code = 0;
                break;
            }

        }
        PlaySequence(type);

        //PlaySequence(CaptureKey());
    }
}

