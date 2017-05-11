/*
 * File:   newmain.c
 * Author: Antonio
 *
 * Created on 30 ????? 2017 ?., 18:33
 */


#include <xc.h>

void main(void) {
    int a[5] = {2,5,1,4,3};
    int min = a[0];
    for (int i = 0; i < 5; i++) {
        min = (a[i] < min ? a[i] : min);
    }

    for (int i =0; i < 4; i++) {
        for (int j =i; j < 5; j++) {
            if (a[i] > a[j]) {
                int temp = a[i];
                a[i] = a[j];
                a[j] = temp;
            }
        }
    }
    for (int i =0; i < 4; i++) {
        for (int j =i; j < 5; j++) {
            if (a[i] < a[j]) {
                int temp = a[i];
                a[i] = a[j];
                a[j] = temp;
            }
        }
    }
    return;
}
