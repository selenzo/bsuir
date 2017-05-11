/*
 * File:   newmain.c
 * Author: Art
 *
 * Created on 25 ??????? 2016 ?., 13:53
 */
#define _XTAL_FREQ 1000000

#include <xc.h>
#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <stdbool.h>
#include <pic16f84a.h>


#define COUNT_NOTES 42

const uint16_t frequences[COUNT_NOTES] = {
    392, 392, 392, 311, 466, 392, 311, 466, 392,
    587, 587, 587, 622, 466, 369, 311, 466, 392,
    784, 392, 392, 784, 739, 698, 659, 622, 659,
    415, 554, 523, 493, 466, 440, 466,
    311, 369, 311, 466, 392, 311, 466, 392 };

const uint16_t durations[COUNT_NOTES] = {
    350, 350, 350, 250, 100, 350, 250, 100, 700,
    350, 350, 350, 250, 100, 350, 250, 100, 700,
    350, 250, 100, 350, 250, 100, 100, 100, 450,
    150, 350, 250, 100, 100, 100, 450,
    150, 350, 250, 100, 350, 250, 100, 450 };

const uint16_t frequences2[COUNT_NOTES] = {
    292, 292, 292, 211, 366, 292, 211, 366, 292,
    587, 587, 587, 622, 466, 369, 311, 466, 392,
    784, 392, 392, 784, 739, 698, 659, 622, 659,
    415, 554, 523, 493, 466, 440, 466,
    311, 369, 311, 466, 392, 311, 466, 392 };

const uint16_t durations2[COUNT_NOTES] = {
    350, 350, 350, 250, 100, 350, 250, 100, 700,
    350, 350, 350, 250, 100, 350, 250, 100, 700,
    350, 250, 100, 350, 250, 100, 100, 100, 450,
    150, 350, 250, 100, 100, 100, 450,
    150, 350, 250, 100, 350, 250, 100, 450 };

const uint16_t* melody_freq[2] = {frequences, frequences2};
const uint16_t* melody_dur[2] = {durations, durations2};

void Play(uint8_t note, uint8_t melody)
{
    uint16_t time = (uint16_t)(7500/melody_freq[melody][note]);
    uint16_t dur = (melody_dur[melody][note]*20)/(time*2);
    uint16_t actual_duration=0;
    while (actual_duration < dur)
    {
        PORTB  |= 0xC0;
        for(uint16_t j =0; j< time;j++)
            __delay_us(1);

        PORTB &= ~0xC0;
        for(uint16_t j =0; j< time;j++)
            __delay_us(1);
        actual_duration++;
    }
}

volatile uint8_t melody;
volatile uint8_t counter;

void interrupt isr() {
    if (INTF) {
        counter = 0;
        melody++;
        if (melody > 2)
            melody =0;
        INTF = 0;
    }
}

void main()
{
    TRISB = 0x3F;
    PORTB = 0x00;
    melody =0;
    counter =0;
    GIE = 0;
    INTEDG = 0;
    INTE = 1;
    GIE =1;

    while(1)
    {
        if (melody){
            if (counter<COUNT_NOTES){
            //for (int i =0; i<COUNT_NOTES;i++)
                Play(counter,melody-1);
                counter++;
            }
            else
            {
                counter = 0;
                //melody = 0;
                __delay_ms(500);
            }
        }
    }
}

