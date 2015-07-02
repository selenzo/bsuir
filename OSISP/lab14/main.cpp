#include "main.h"

/*

SC_HANDLE OpenSCManager(
LPCTSTR lpszMachineName,   // адрес имени рабочей станции
LPCTSTR lpszDatabaseName,  // адрес имени базы данных
DWORD   fdwDesiredAccess); // нужный тип доступа


BOOL ControlService(
SC_HANDLE hService,                // идентификатор сервиса
DWORD     dwControl,               // код команды
LPSERVICE_STATUS lpServiceStatus); // адрес структуры состояния
// сервиса SERVICE_STATUS

BOOL EnumServicesStatus(
SC_HANDLE hSCManager,	// handle, полученный при открытии менеджера сервисов
DWORD dwServiceType,	// тип перечисляемых сервисов
DWORD dwServiceState,	// состояние перечисляемых сервисов
LPENUM_SERVICE_STATUS lpServices,	// указатель на буфер, в который сохраняется статус сервисов
DWORD cbBufSize,	// размер буфера
LPDWORD pcbBytesNeeded,	// Переменная, получающая требуемый объем буфера в байтах
LPDWORD lpServicesReturned,	// Переменная, получающая кол-во возвращенных записей
LPDWORD lpResumeHandle 	// Переменная, получающая Handle следующего вхождения (для маленького буфера)
);

SC_HANDLE WINAPI OpenService(
_In_  SC_HANDLE hSCManager,
_In_  LPCTSTR lpServiceName,
_In_  DWORD dwDesiredAccess
);

*/
#define SIZE_BUF 4096

int main(int argc, char *argv[])
{
	ENUM_SERVICE_STATUS Status[SIZE_BUF];
	SERVICE_STATUS newStatus;
	DWORD Size = sizeof(Status);
	DWORD Needed = 0;
	DWORD Return = 0;
	DWORD Handle = 0;
	SC_HANDLE Manager;

	Manager = OpenSCManager(NULL, NULL, SC_MANAGER_ALL_ACCESS);

	if (Manager != NULL)
	{
		if (EnumServicesStatus(Manager, SERVICE_WIN32, SERVICE_STATE_ALL, (LPENUM_SERVICE_STATUS)&Status, Size, &Needed, &Return, &Handle))
		{
			for (unsigned int x = 0; x < Return; x++)
			{
				wcout << Status[x].lpServiceName << endl;
				GetStatus(Status[x].ServiceStatus.dwCurrentState);
			}
				
		}
		else cout << "Error Open Manager " << endl;
	}
	else cout << "Error enum Services" << endl;
	system("pause");
	system("cls"); 

	SC_HANDLE schService = OpenService(Manager, L"WebClient", SERVICE_ALL_ACCESS);
	
	//проверям что служба выключена
	QueryServiceStatus(schService, &newStatus);
	GetStatus(newStatus.dwCurrentState);
	//включаем и ждем две секунды на применение
	StartService(schService, NULL, NULL);
	Sleep(2000);
	//проверям что служюа включилась
	QueryServiceStatus(schService, &newStatus);
	GetStatus(newStatus.dwCurrentState);
	//выключаем ее обратно
	ControlService(schService, SERVICE_CONTROL_STOP, &newStatus);
	GetStatus(newStatus.dwCurrentState);
	//ждем 2 секунды и смотрим что получилось
	Sleep(2000);
	QueryServiceStatus(schService, &newStatus);
	GetStatus(newStatus.dwCurrentState);

	CloseServiceHandle(schService);
	CloseServiceHandle(Manager);
	
	system("pause");

	return 0;
}

void GetStatus(int code)
{
	switch (code)
	{
	case 1:
		cout << "SERVICE_STOPPED" << endl;
		break;
	case 2:
		cout << "SERVICE_START_PENDING" << endl;
		break;
	case 3:
		cout << "SERVICE_STOP_PENDING" << endl;
		break;
	case 4:
		cout << "SERVICE_RUNNING" << endl;
		break;
	case 5:
		cout << "SERVICE_CONTINUE_PENDING" << endl;
		break;
	case 6:
		cout << "SERVICE_PAUSE_PENDING" << endl;
		break;
	case 7:
		cout << "SERVICE_PAUSED" << endl;
		break;
	}
}