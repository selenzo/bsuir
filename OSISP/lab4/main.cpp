#include "main.h"

/*
DWORD WaitForSingleObject(
	HANDLE hHandle, // дескриптор объекта
	DWORD dwMilliseconds // интервал ожидания в миллисекундах
);

DWORD WaitForMultipleObjects(
	DWORD nCount, // количество объектов
	CONST HANDLE *lpHandles, // массив дескрипторов объектов
	BOOL bWaitAll, // режим ожидания
	DWORD dwMilliseconds // интервал ожидания в миллисекундах
);

HANDLE CreateMutex(
	LPSECURITY_ATTRIBUTES lpMutexAttributes, // атрибуты защиты
	BOOL bInitialOwner, // начальный владелец мьютекса
	LPCTSTR lpName // имя мьютекса
);

BOOL ReleaseMutex(
	HANDLE hMutex // дескриптор мьютекса
);
*/
HANDLE hMutex;

int main(int argc, char *argv[])
{
	HANDLE hThread[2];
	DWORD IDThread1, IDThread2;

	int id = 1;

	//hMutex = OpenMutex(SYNCHRONIZE, FALSE, L"DemoMutex");
	hMutex = CreateMutex(NULL, FALSE, L"MyMutex");
	if (hMutex == NULL)
	{
		cout << "Open mutex failed." << endl;
		cout << "Press any key to exit." << endl;
		system("pause");
		return GetLastError();
	}

	hThread[0] = CreateThread(NULL, 0, Thread, (void*)id, 0, &IDThread1);
	if (hThread[0] == NULL)
		return GetLastError();

	id++;
	
	hThread[1] = CreateThread(NULL, 0, Thread, (void*)id, 0, &IDThread2);
	if (hThread[1] == NULL)
		return GetLastError();
	
	//ждем завершения всех процессов
	WaitForMultipleObjects(2, hThread, TRUE, INFINITE);
	// закрываем дескриптор объекта
	CloseHandle(hMutex);
	CloseHandle(hThread[0]);
	CloseHandle(hThread[1]);

	system("pause");
	return 0;
}

DWORD WINAPI Thread(LPVOID iNum)
{
	for (int i = 0; i < 10; i++)
	{
		WaitForSingleObject(hMutex, INFINITE);

		cout << "thread " << (int)iNum << endl;

		ReleaseMutex(hMutex);
	}
	return 0;
}