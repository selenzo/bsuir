/******************************************************************************/
/* Files to Include                                                           */
/******************************************************************************/

#if defined(__XC)
    #include <xc.h>         /* XC8 General Include File */
#elif defined(HI_TECH_C)
    #include <htc.h>        /* HiTech General Include File */
#endif

#include <stdint.h>        /* For uint8_t definition */
#include <stdbool.h>       /* For true/false definition */

#include "system.h"        /* System funct/params, like osc/peripheral config */
#include "user.h"          /* User funct/params, such as InitApp */
#include <pic16f84a.h>
/******************************************************************************/
/* User Global Variable Declaration                                           */
/******************************************************************************/

/* i.e. uint8_t <variable_name>; */

/******************************************************************************/
/* Main Program                                                               */
/******************************************************************************/
void main(void)
{

//
//TRISB = 0xF0;
//    TRISA = 0xF0;
//
//    PORTB = 0x02;
    int a[5] = {1,2,3,4,5};
    for (int i = 0; i < 5; i++) {
        a[i] = 0;
    }
    while(1)
    {
        /* TODO <INSERT USER APPLICATION CODE HERE> */
    }

}

