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

#define COUNT_NOTES 39
#pragma config WDTE = OFF

//??????? ????
const uint16_t frequences[COUNT_NOTES] = {
    329, 392, 440, 329, 392, 466, 440, 329, 392, 440,392,329,329,329,329 };

//???????????? ???
const uint16_t durations[COUNT_NOTES] = {
    300, 300, 600, 300, 300, 200, 700, 300, 300, 600, 300, 600,150,150,150};



void Play(uint8_t note)
{
    uint16_t i=0;
    int j=0;
    uint16_t time = (uint16_t)(20000/(frequences[note]));
    uint16_t time2 = time;
    for (i=0;i<durations[note]/2;i++)
//    while(1)
    {
        PORTB |= 0x80;
        while(time>0){
            __delay_us(1);
            time -=1;
        }
        //_delay((unsigned long)((time)*(_XTAL_FREQ/4000000.0)));
//        __delay_us(time);
        PORTB &= ~0x80;
        time = time2;
        while(time>0){
            __delay_us(1);
            time -=1;
        }
  //      __delay_ms(1000);
       // for(j=0;j<(time)*(_XTAL_FREQ/400000.0);j++);
    }
}

void main()
{
    TRISB = 0x7F;
    PORTB = 0x00;

    uint8_t melody = 0;
    uint8_t i =0;
    while(1)
    {
//        if((PORTB & 0x01) == 0x00){
//            while((PORTB & 0x01) == 0x00);
//            if(melody < 2) melody++;
//            else melody = 0;
//        }
//        PORTA = melody;
        for (i=0;i<COUNT_NOTES; i++){
            Play(i);
            //__delay_ms(1000);
        }
    }
}

