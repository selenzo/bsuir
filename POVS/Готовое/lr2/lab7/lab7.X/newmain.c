/*
 * File:   newmain.c
 */
#define _XTAL_FREQ 1000000
#pragma config WDTE = OFF
#include <pic16f84a.h>
#include <stdlib.h>
#include <stdint.h>
#include <htc.h>
#include "hd44780.h"

void main()
{
    TRISA = 0xFF;
    TRISB = 0x00;
    PORTB = 0x00;
    LCDInit();
    uint8_t univercity[] = {"BSUIR"};
    uint8_t lastname[] = {"POIT"};
    LCDPutString(univercity,1,7);
    LCDPutString(lastname,2,3);
    while(1)
    {

    }
}
