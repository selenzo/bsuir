/*
 * File:   newmain.c
 * Author: Antonio
 *
 * Created on 30 ????? 2017 ?., 18:42
 */


#include <xc.h>

void main(void) {
    int temp;
    __EEPROM_DATA (0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08);
    return;
}
