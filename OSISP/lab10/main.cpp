#include "main.h"

bool fileEnd = false, freeRead = false, freeCalc = false;
int *buf1, *buf2, *currentBuf;
int currentLength = 0;
int result = 0;

/*

Показать пример кеширования сложно, ибо кеширование это запоминание часто использхуемых файлов
В данном случае есть два варианта решения
1) 

char buf[BUFSIZ];
FILE *stream1, *stream2;

fopen_s( &stream1, "data1", "a" );
fopen_s( &stream2, "data2", "w" );

if( (stream1 != NULL) && (stream2 != NULL) )
{
// "stream1" uses user-assigned buffer:
setbuf( stream1, buf ); // C4996
// Note: setbuf is deprecated; consider using setvbuf instead
printf( "stream1 set to user-defined buffer at: %Fp\n", buf );

// "stream2" is unbuffered
setbuf( stream2, NULL ); // C4996
printf( "stream2 buffering disabled\n" );
_fcloseall();
}

тут используется функция setbuf которая устанавливает размер буфера ввода/вывода

2)
Код ниже реализует двойную буферизацию, которая используется в системе.
Идея такова: Пока один поток пишет в один буфер данные, второй поток из второго 
буфера использует данные. Затем по окончанию операций указатели на буферы свапаются.

*/
int main(int argc, char *argv[])
{
	HANDLE hThread[2];
	DWORD IDThread1, IDThread2;
	//инициализируем два буфера
	buf1 = new int[10];
	buf2 = new int[10];
	currentBuf = buf1;
	
	hThread[0] = CreateThread(NULL, 0, ReadFile, (void*)result, 0, &IDThread1);
	if (hThread[0] == NULL)
		return GetLastError();

	hThread[1] = CreateThread(NULL, 0, Calc, (void*)result, 0, &IDThread2);
	if (hThread[1] == NULL)
		return GetLastError();

	WaitForMultipleObjects(2, hThread, TRUE, INFINITE);
	// закрываем дескриптор объекта
	 
	CloseHandle(hThread[0]);
	CloseHandle(hThread[1]);
	
	delete(buf1);
	delete(buf2);
	
	cout << result << endl;
	system("pause");
	return 0;
}

DWORD WINAPI ReadFile(LPVOID iNum)
{
	int *temp;
	int tempLength = 0;
	temp = currentBuf;
	ifstream inf("test.txt");
	
	while (!inf.eof())
	{
		if (tempLength < 5)
		{
			cout << "read " << endl;
			inf >> temp[tempLength];
			tempLength++;
		} 
		else
		{
			while (freeCalc){				
			}
			currentBuf = temp;
			currentLength = tempLength;
			temp = (temp == buf1 ? buf2 : buf1);
			tempLength = 0;
			freeCalc = true;
		}
	}
	while (freeCalc){
	}
	currentBuf = temp;
	currentLength = tempLength;
	fileEnd = true;

	inf.close();
	return 0;
}

DWORD WINAPI Calc(LPVOID iNum)
{
	while (!fileEnd)
	{
		if (freeCalc)
		{
			for (int i = 0; i < currentLength; i++)
			{
				cout << "calc " << endl;
				result += currentBuf[i];
			}
			freeRead = true;
			freeCalc = false;
		}
	}
	if (currentLength > 0)
	{
		for (int i = 0; i < currentLength; i++)
		{
			result += currentBuf[i];
		}
		freeRead = true;
		freeCalc = false;
	}

	return 0;
}