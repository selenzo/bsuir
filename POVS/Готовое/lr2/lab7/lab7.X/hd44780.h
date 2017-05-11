/*
 * hd44780.h
 *
 * Created: 07.09.2015 11:09:00
 *  Author: Art
 */

/* Define to prevent recursive inclusion -------------------------------------*/
#ifndef __HD44780_H
#define __HD44780_H

/* Includes ------------------------------------------------------------------*/

void SendByte(uint8_t);
void LCDSendCommand(uint8_t);
void LCDSendData(uint8_t);
void LCDInit(void);
void LCDPutChar(uint8_t, uint8_t, uint8_t);
void LCDPutString(char*, uint8_t, uint8_t);

#endif //HD44780.h
