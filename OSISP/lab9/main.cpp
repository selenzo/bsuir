#include "main.h"




int main(int argc, char *argv[])
{
	cout << "curret attr:" << endl;
	DWORD dAttr = GetFileAttributes(L"test.txt");
	ShowAttributes(dAttr);
	cout << endl << "Set normal attr:" << endl;
	SetFileAttributes(L"test.txt", FILE_ATTRIBUTE_NORMAL);
	dAttr = GetFileAttributes(L"test.txt");
	ShowAttributes(dAttr);

	cout << endl << "Set system, hidden,archive,temporary, readonly attr:" << endl;
	SetFileAttributes(L"test.txt", FILE_ATTRIBUTE_ARCHIVE | FILE_ATTRIBUTE_HIDDEN | FILE_ATTRIBUTE_SYSTEM | FILE_ATTRIBUTE_TEMPORARY | FILE_ATTRIBUTE_READONLY);
	dAttr = GetFileAttributes(L"test.txt");
	ShowAttributes(dAttr);

	system("pause");
	return 0;
}

void ShowAttributes(DWORD attributes)
{
	if (attributes & FILE_ATTRIBUTE_ARCHIVE)
		cout << "archive\n";
	if (attributes & FILE_ATTRIBUTE_DIRECTORY)
		cout << "directory\n";
	if (attributes & FILE_ATTRIBUTE_HIDDEN)
		cout << "hidden\n";
	if (attributes & FILE_ATTRIBUTE_NORMAL)
		cout << "normal\n";
	if (attributes & FILE_ATTRIBUTE_READONLY)
		cout << "read only\n";
	if (attributes & FILE_ATTRIBUTE_SYSTEM)
		cout << "system\n";
	if (attributes & FILE_ATTRIBUTE_TEMPORARY)
		cout << "temporary\n";
}
