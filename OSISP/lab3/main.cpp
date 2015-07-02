#include "main.h"

/*
HANDLE CreateThread(
	LPSECURITY_ATTRIBUTES lpThreadAttributes, // атрибуты защиты
	DWORD dwStackSize, // размер стека потока в байтах
	LPTHREAD_START_ROUTINE lpStartAddress,// адрес исполняемой функции
	LPVOID lpParameter,// адрес параметра
	DWORD dwCreationFlags,// флаги создания потока
	LPDWORD lpThreadId// идентификатор потока
);

DWORD WINAPI ThreadProc (LPVOID lpParameters); //прототип для функций, выполняемых в потоке
*/

int n = 0;

int main(int argc, char *argv[])
{
	int inc = 10;
	HANDLE hThread;
	DWORD IDThread;
	cout << "n = " << n << endl;
	hThread = CreateThread(NULL, 0, Add, (void*)inc, 0, &IDThread);
	if (hThread == NULL)
		return GetLastError();
	// ждем пока поток Add закончит работу
	WaitForSingleObject(hThread, INFINITE);
	// закрываем дескриптор потока Add
	CloseHandle(hThread);
	cout << "n = " << n << endl;

	system("pause");
	return 0;
}

DWORD WINAPI Add(LPVOID iNum)
{
	cout << "Thread is started." << endl;
	n += (int)iNum;
	cout << "Thread is finished." << endl;
	return 0;
}