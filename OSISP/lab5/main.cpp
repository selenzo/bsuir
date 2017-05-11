#include "main.h"

/*
BOOL WINAPI GetProcessTimes(
	_In_   HANDLE hProcess,				//дескриптор, указывающий на открытый хэндл процесса
	_Out_  LPFILETIME lpCreationTime,	//время создания процесса
	_Out_  LPFILETIME lpExitTime,		//время выходного времени
	_Out_  LPFILETIME lpKernelTime,		//время, которое процесс уже висит в режиме ядра
	_Out_  LPFILETIME lpUserTime		//время, которое процесс висит в режиме пользователя.
);
*/

int main(int argc, char *argv[])
{
	time_t seconds = time(NULL);
	tm* timeinfo = localtime(&seconds);

	HANDLE hProcess = GetCurrentProcess();
	FILETIME ft[4];
	SYSTEMTIME sysTime[4];
	string str;

	GetProcessTimes(hProcess, &ft[0], &ft[1], &ft[2], &ft[3]);

	FileTimeToSystemTime(&ft[3], &sysTime[3]);

	printf("UserTime %u/%u/%u  %u:%u:%u:%u\n", sysTime[3].wYear, sysTime[3].wMonth, sysTime[3].wDay,
		sysTime[3].wHour, sysTime[3].wMinute, sysTime[3].wSecond, sysTime[3].wMilliseconds);
	cout << "Current " << asctime(timeinfo) << endl;

	for (int i = 0; i < 1000; i++)
	{
		for (int j = 0; j < 1000000; j++)
		{
			j = j;
		}
	}

	GetProcessTimes(hProcess, &ft[0], &ft[1], &ft[2], &ft[3]);

	FileTimeToSystemTime(&ft[3], &sysTime[3]);

	printf("UserTime %u/%u/%u  %u:%u:%u:%u\n", sysTime[3].wYear, sysTime[3].wMonth, sysTime[3].wDay,
		sysTime[3].wHour, sysTime[3].wMinute, sysTime[3].wSecond, sysTime[3].wMilliseconds);

	seconds = time(NULL);
	timeinfo = localtime(&seconds);
	cout << "Current " << asctime(timeinfo) << endl;

	system("pause");

	return 0;
}
