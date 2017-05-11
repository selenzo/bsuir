.MODEL tiny
.STACK 100h
.DATA
String db 5 dup (?),'$' ; Резервируем 5 байт для строки
StringEnd = $-1 ; Указывает на символ '$'
Number = 6219
Mes_1 db 0dh, 0ah, "Chislo 6219 v 16-y sisiteme schisleniya - ", "$" 
Mes_2 db 0dh, 0ah, "Chislo 6219 v 8-y sisiteme schisleniya - ", "$" 
Mes_3 db 0dh, 0ah, "Chislo 6219 v 2-y sisiteme schisleniya - ", "$" 

Flag db 01h
.CODE
ORG 100h

Start:
push ax
push bx
push cx
push dx 

mov ax,@data
mov ds,ax
mov es,ax 

lea dx,Mes_1
mov ah,09h
int 21h

mov bl,Flag

;------------------Перевод числа в 16-ю с.с.-----------------------------

std ; Устанавливаем ОБРАТНЫЙ порядок записи
lea di,StringEnd-1 ; ESI = последний символ строки String
mov ax,Number ; Заносим в AX число для перевода
mov cx,16 ; Задаемся делителем CX = 16
_16_System:
xor dx,dx ; Обнуляем DX (для деления)
div cx ; Делим DX:AX на CX (16),
; Получаем в AX частное, в DX остаток
xchg ax,dx ; Меняем их местами (нас интересует остаток)
add al,'0' ; Получаем в AL символ цифры
cmp al,'9' ; Проверяем если цифра
jbe zapis ; Переходим на запись

add al,'A'-('9'+1) ; Если символ, корректируем
jmp zapis

zapis: 
stosb ; И записываем ее в строку

cmp bl,04h
jge zap_2
jmp zap_16_8
zap_2: 
inc di
; dec ch
cmp ch,0Fh
jne Met
jmp vivod

zap_16_8: xchg ax,dx ; Восстанавливаем AX (частное)
or ax,ax ; Сравниваем AX с 0
jne _16_System ; Если не ноль, то повторяем
jmp vivod

;------------------Перевод числа в 8-ю с.с.-----------------------------

_8_System: 
lea dx,Mes_2
mov ah,09h
int 21h 

std ; Устанавливаем ОБРАТНЫЙ порядок записи
lea di,StringEnd-1 ; ESI = последний символ строки String
mov ax,Number ; Заносим в AX число для перевода
mov cx,8 ; Задаемся делителем CX = 8
jmp _16_System

;-----------------Перевод числа в 2-ю с.с.-------------------------------

_2_System: 
lea dx,Mes_3
mov ah,09h
int 21h
std ; Устанавливаем ОБРАТНЫЙ порядок записи
lea di,StringEnd-1 ; ESI = последний символ строки String
mov ax,Number ; Заносим в AX число для перевода
mov cl,16-1 ; 16-битный регистр, будем выводить по 4 бита (0..F)
xchg dx,ax ; Сохраняем число в DX

mov ch,0

Met:
mov ax,dx ; Восстанавливаем число в AX
shr ax,cl ; Сдвигаем на CL бит вправо
and al,1 ; Получаем в AL цифру 0..15
add al,'0' ; Получаем в AL символ цифры
sub cl,1 ; Уменьшаем CL на 1 для следующей цифры
inc ch 
jnc zapis ; Если знаковый CL >= 0, то повторяем 
; И записываем ее в строку
jmp zapis

;z1: 
; inc di
; dec ch
; cmp ch,0
; jne z1
; jmp vivod

;-----------------Вывод строки на экран----------------------------------
vivod:
mov ah,09h
; lea dx,[di+1] ; Заносим в DX адрес начала строки
lea dx,String ; Заносим в DX адрес начала строки
int 21h ; Выводим ее на экран
add bl,01h
cmp bl,02h
je _8_System

add bl,01h
cmp bl,04h
je _2_System

mov ax,4c00h
int 21h ; Выходим из программы

push ax
push bx
push cx
push dx 

END Start