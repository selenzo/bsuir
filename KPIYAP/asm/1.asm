assume CS: code, DS: data
code segment
begin:
mov AX, data
mov DS, AX

mov AH, 09h
mov DX, offset mes1
int 21h

mov cx,10
mov si,0

show_primary:
mov dl,mas[si]
;add dl,30h ;! работаем уже с самими символами
mov ah,02h
int 21h
inc si
loop show_primary

lea dx,nl ;переход на новую строку
mov ah,9
int 21h

mov i,0 ;for i := 0 to n - 1 do
i_loop:
mov j,1 ; for j := 1 to n - 1 do
j_loop: ; begin
mov bx,j ; 
mov al,mas[bx-1] ; al := mas[j - 1];
mov ah,mas[bx] ; ah := mas[j];
cmp al,ah ; if al >= ah then
jb next_j ; begin
mov mas[bx],al ; a[j] := al;
mov mas[bx-1],ah ; a[j - 1] := ah;
next_j: ; end;
inc j
cmp j,n
jb j_loop ; end;
inc i
cmp i,n
jb i_loop

mov AH, 09h
mov DX, offset mes2
int 21h

mov cx,10
mov si,0

show:
mov dl,mas[si]
;add dl,30h ;! работаем уже с самими символами
mov ah,02h
int 21h
inc si
loop show

lea dx,nl ;переход на новую строку
mov ah,9
int 21h

mov AH, 08h
int 21h

mov AH, 4Ch
mov AL, 00h
int 21h

code ends

data segment
mes1 db 'Primary Massiv: $'
mes2 db 'Massiv After Sorted: $'
nl db 13,10,'$'
n equ 10
mas db 'qwertydfgh'
i dw 0
j dw 0
temp db 0
data ends

stk segment stack
dw 128 dup (0)
stk ends

end begin