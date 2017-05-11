#include "main.h"

/*
BOOL CreateProcess(
	LPCTSTR lpApplicationName, // имя исполняемого модуля
	LPTSTR lpCommandLine, // командная строка
	LPSECURITY_ATTRIBUTES lpProcessAttributes, // атрибуты защиты процесса
	LPSECURITY_ATTRIBUTES lpThreadAttributes, // атрибуты защиты потока
	BOOL bInheritHandle, // наследуемый ли дескриптор
	DWORD dwCreationFlags, // флаги создания процесса
	LPVOID lpEnvironment, // блок новой среды окружения
	LPCTSTR lpCurrentDirectory, // текущий каталог
	LPSTARTUPINFO lpStartUpInfo, // вид главного окна
	LPPROCESS_INFORMATION lpProcessInformation // информация о процессе

);
*/

int main(int argc, char *argv[])
{
	const wchar_t lpszAppName[17] = L"test_process.exe";
	STARTUPINFO si;
	PROCESS_INFORMATION piApp;
	ZeroMemory(&si, sizeof(STARTUPINFO));
	si.cb = sizeof(STARTUPINFO);
	// создаем новый консольный процесс
	if (!CreateProcess(lpszAppName, NULL, NULL, NULL, FALSE,
		CREATE_NEW_CONSOLE, NULL, NULL, &si, &piApp))
	{
		cout << "The new process is not created.\n";
		system("pause");
		return 0;
	}
	cout << "The new process is created.\n";
	// ждем завершения созданного прцесса
	WaitForSingleObject(piApp.hProcess, INFINITE);
	// закрываем дескрипторы этого процесса в текущем процессе
	CloseHandle(piApp.hThread);
	CloseHandle(piApp.hProcess);
	cout << "Process closed.\n";
	system("pause");
	return 0;
}