/*
 * File:   newmain.c
 */
#define _XTAL_FREQ 1000000
#pragma config WDTE = OFF

#include <pic16f84a.h>
#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <string.h>
#include <stdbool.h>
#include <htc.h>

#define psw1 "1111"
#define psw2 "2222"
#define psw3 "3333"
#define psw4 "4444"

#define usr1 "1111"
#define usr2 "2222"
#define usr3 "3333"
#define usr4 "4444"


uint8_t CaptureKey()
{
    PORTB = 0x04;
    switch(PORTB & 0xF0){
        case 0x10:
            while((PORTB & 0x10) == 0x10);
            return '1';
        case 0x20:
            while((PORTB & 0x20) == 0x20);
            return '4';
        case 0x40:
            while((PORTB & 0x40) == 0x40);
            return '7';
        case 0x80:
            while((PORTB & 0x80) == 0x80);
            return '*';
    }
    PORTB = 0x02;
    switch(PORTB & 0xF0){
        case 0x10:
            while((PORTB & 0x10) == 0x10);
            return '2';
        case 0x20:
            while((PORTB & 0x20) == 0x20);
            return '5';
        case 0x40:
            while((PORTB & 0x40) == 0x40);
            return '8';
        case 0x80:
            while((PORTB & 0x80) == 0x80);
            return '8';
    }
    PORTB = 0x01;
    switch(PORTB & 0xF0){
        case 0x10:
            while((PORTB & 0x10) == 0x10);
            return '3';
        case 0x20:
            while((PORTB & 0x20) == 0x20);
            return '6';
        case 0x40:
            while((PORTB & 0x40) == 0x40);
            return '9';
        case 0x80:
            while((PORTB & 0x80) == 0x80);
            return '#';
    }
    return 0xAA;
}

void main()
{
    TRISA = 0xE0;
    TRISB = 0xF8;
    PORTA = 0x0F;
    PORTB = 0x07;
    uint8_t data[4] = {0x00, 0x00, 0x00, 0x00};
    uint8_t position = 0;
    bool usr_entry_enabled = false;
    bool usr_entry_succeed = false;
    bool psw_entry_enabled = false;

    while(1)
    {
        uint8_t temp = CaptureKey();
        if((temp == '*')&&(!usr_entry_enabled)&&(!usr_entry_succeed)&&(!psw_entry_enabled)){
            usr_entry_enabled = true;
            temp = 0xAA;
            //PORTA = 0x0A;
        }
        if(usr_entry_succeed &&(temp == '#')){
            usr_entry_succeed = false;
            psw_entry_enabled = true;
            temp = 0xAA;
            //PORTA = 0x0D;
        } else if(temp == '#'){
            usr_entry_enabled = false;
            usr_entry_succeed = false;
            PORTA = 0x0E;
            __delay_ms(500);
            PORTA = 0x0F;
        }
        if(usr_entry_enabled){
            if(position < 4){
                if(temp != 0xAA){
                    data[position++] = temp;
                }
            }
            else{
                position = 0;
                if((!strncmp(data, usr1, 4))||(!strncmp(data, usr2, 4))||(!strncmp(data, usr3, 4))||(!strncmp(data, usr4, 4))){
                    usr_entry_enabled = false;
                    usr_entry_succeed = true;
                    //PORTA = 0x08;
                }else{
                    PORTA = 0x0E;
                  __delay_ms(500);
                    PORTA = 0x0F;
                    usr_entry_enabled = false;
                }
            }
        }
        if(psw_entry_enabled){
            if(position < 4){
                if(temp != 0xAA){
                    data[position++] = temp;
                }
            }
            else{
                position = 0;
                if((!strncmp(data, psw1, 4))||(!strncmp(data, psw2, 4))||(!strncmp(data, psw3, 4))||(!strncmp(data, psw4, 4))){
                    PORTA = 0x00;
                    __delay_ms(500);
                    PORTA = 0x0F;
                }else{
                    PORTA = 0x0E;
                    __delay_ms(500);
                    PORTA = 0xF;
                    psw_entry_enabled = false;
                }
            }
        }
    }
}

