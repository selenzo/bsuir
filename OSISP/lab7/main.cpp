#include "main.h"

/*

LONG RegCreateKeyEx(
HKEY hKey,		// дескриптор открытого ключа
LPCTSTR lpSubKey,	// адрес имени подключа
DWORD Reserved,	// зарезервировано
LPTSTR lpClass,	// адрес строки класса
DWORD dwOptions,	// флаг особых опций
REGSAM samDesired,	// желаемый доступ безопасности
LPSECURITY_ATTRIBUTES lpSecurityAttributes,	// адрес структуры
// ключа безопасности
PHKEY phkResult,	// адрес буфера для открытого ключа
LPDWORD lpdwDisposition 	// адрес буфера характерного значения
);

LONG RegSetValueEx(
HKEY hKey,		// дескриптор ключа
LPCTSTR lpValueName,// адрес имени установливаемого значения
DWORD Reserved,	// зарезервировано
DWORD dwType,	// тип данных
CONST BYTE *lpData,	// адрес данных для установки
DWORD cbData		// размер данных
);

LONG RegOpenKeyEx(
HKEY hKey,	// дескриптор указанного ключа
LPCTSTR lpSubKey,	// адрес имени открываемого подключа
DWORD ulOptions,	// зарезервировано
REGSAM samDesired,	// маска доступа безопасности
PHKEY phkResult 	// адрес дескриптора открытого ключа
);

LONG RegQueryValueEx(
HKEY hKey,		// дескриптор ключа
LPTSTR lpValueName,	// адерс имени значения
LPDWORD lpReserved,	// зарезервировано
LPDWORD lpType,	// адрес переменной для типа значения
LPBYTE lpData,	// адрес буфера для данных
LPDWORD lpcbData 	// адрес переменной для размер буфера данных
);

LONG RegDeleteValue(
HKEY hKey,	// дескриптор ключа
LPCTSTR lpValueName 	// адрес имени значения
);

LONG WINAPI RegDeleteKeyValue(
_In_      HKEY hKey,
_In_opt_  LPCTSTR lpSubKey,
_In_opt_  LPCTSTR lpValueName
);
*/

int main(int argc, char *argv[])
{
	HKEY hKey;
	DWORD test1 = 1;
	wchar_t test2[5] = L"test";
	//создаем раздел Magic в HKEY_CURRENT_USER\\SOFTWARE\\Magic
	if (!RegCreateKeyEx(HKEY_CURRENT_USER, L"SOFTWARE\\Magic", 0, NULL, REG_OPTION_NON_VOLATILE, KEY_ALL_ACCESS, NULL, &hKey, NULL))
	{
		//Если все хорошо, создаем там параметр MyKey
		if (RegSetValueEx(hKey, L"MyKey1", 0, REG_DWORD, (LPBYTE)&test1, sizeof(DWORD)))
		{
			cout << "error RegSetValueEx1\n";
			return GetLastError();
		}

		if (RegSetValueEx(hKey, L"MyKey2", 0, REG_SZ, (LPBYTE)&test2, sizeof(test2)))
		{
			cout << "error RegSetValueEx2\n";
			return GetLastError();
		}
	}
	else
	{
		cout << "error RegCreateKeyEx\n";
		return GetLastError();
	}
	//закрываем ключ
	RegCloseKey(hKey);

	cout << "HKEY_CURRENT_USER\\SOFTWARE\\Magic created" << endl;
	system("pause");
	
	if (!RegOpenKeyEx(HKEY_CURRENT_USER, L"SOFTWARE\\Magic", 0, KEY_READ, &hKey))
	{

		DWORD pvData = { 0 };
		DWORD pcbData = sizeof (pvData);
		if (RegGetValue(hKey, NULL, L"MyKey1", RRF_RT_REG_DWORD, 0, &pvData, &pcbData))
		{
			cout << "error RegGetValue\n";
			return GetLastError();
		}
		cout << "MyKey1: " << pvData << endl;

		char cData[5] = { 0 };
		DWORD bufSize = sizeof cData;
		
		if (RegGetValueA(hKey, NULL, "MyKey2", RRF_RT_REG_SZ, 0, &cData, &bufSize))
		{
			cout << "error RegGetValue\n";
			return GetLastError();
		}
		cout << "MyKey2: " << cData << endl;
	}
	else
	{
		cout << "error RegOpenKeyEx\n";
		return GetLastError();
	}
	//Закрываем ключ реестра
	RegCloseKey(hKey);

	system("pause");
	
	if (!RegOpenKeyEx(HKEY_CURRENT_USER, L"SOFTWARE", 0, KEY_READ, &hKey))
	{
		if (RegDeleteKeyValue(hKey, L"Magic", L"MyKey1"))
		{
			cout << "error RegDeleteKeyValue\n" << GetLastError();
			return GetLastError();
		}

	}
	else
	{
		cout << "error RegOpenKeyEx\n";
		return GetLastError();
	}
	//Закрываем ключ реестра
	RegCloseKey(hKey);

	cout << "HKEY_CURRENT_USER\\SOFTWARE\\Magic\\Mykey1 deleted" << endl;
	system("pause");

	if (!RegOpenKeyEx(HKEY_CURRENT_USER, L"SOFTWARE", 0, KEY_READ, &hKey))
	{
		if (RegDeleteKey(hKey, L"Magic"))
		{
			cout << "error RegDeleteValue\n" << GetLastError();
			return GetLastError();
		}
	}
	else
	{
		cout << "error RegOpenKeyEx\n";
		return GetLastError();
	}
	
	cout << "HKEY_CURRENT_USER\\SOFTWARE\\Magic deleted" << endl;
	system("pause");

	return 0;
}