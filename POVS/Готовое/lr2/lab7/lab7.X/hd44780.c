/*
 * hd44780.c
 *
 */
#define _XTAL_FREQ 1000000

#include <pic16f84a.h>
#include <stdint.h>
#include <htc.h>
#include "hd44780.h"

/*user defines*/
#define SH_CP PD7
#define ST_CP PD6
#define DS PD5
#define _3_WIRE_INTERFACE
//#define _1_WIRE_INTERFACE

#define Set_CLK PORTD |= _BV(SH_CP)
#define Reset_CLK PORTD &= ~_BV(SH_CP)
#define Set_Data PORTD |= _BV(DS)
#define Reset_Data PORTD &= ~_BV(DS)
#define Set_Latch PORTD |= _BV(ST_CP)
#define Reset_Latch PORTD &= ~_BV(ST_CP)

/*define function prototypes*/
//void SendByte(uint8_t);
//void SystickDelay(uint16_t);
//void LCDSendCommand(uint8_t);
//void LCDSendData(uint8_t);
//void LCDInit(void);
//void LCDPutChar(uint8_t, uint8_t, uint8_t);
//void LCDPutString(char*, uint8_t, uint8_t);

void SendByte(uint8_t data)
{
	PORTB = data;
    __delay_ms(1);
}

void LCDSendCommand(uint8_t command)
{
	uint8_t temp = command & 0xF0;
	SendByte(temp | 0x02);
	SendByte(temp);
	temp = command & 0x0F;
	temp <<= 4;
	SendByte(temp | 0x02);
	SendByte(temp);
}

void LCDSendData(uint8_t data)
{
	uint8_t temp = data & 0xF0;
	SendByte(temp | 0x03);
	SendByte(temp | 0x01);
	temp = data & 0x0F;
	temp <<= 4;
	SendByte(temp | 0x03);
	SendByte(temp | 0x01);
}

void LCDInit(void)
{
	SendByte(0x22);
	SendByte(0x20);

	LCDSendCommand(0x28);
	LCDSendCommand(0x0C);
	LCDSendCommand(0x01); //clear display
	LCDSendCommand(0x06);

}

void LCDPutChar(uint8_t chr, uint8_t row, uint8_t column)
{
	uint8_t temp = (row - 1)*0x40 + column - 1;
	LCDSendCommand(temp | 0x80);
	LCDSendData(chr);
}

void LCDPutString(char *ptrdata, uint8_t row, uint8_t column)
{
	uint8_t temp = (row - 1)*0x40 + column - 1;
	LCDSendCommand(temp | 0x80);
	while (*(ptrdata) != '\0')
	{
		LCDSendData(*(ptrdata));
		ptrdata = ptrdata + 1;
	}
}
