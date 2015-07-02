#include "main.h"

/*
http://wm-help.net/books-online/book/59464.html

старый добрый джефри спасает
на протяжении всех лаб

*/
int main(int argc, char *argv[])
{

	MEMORYSTATUS ms = { sizeof(ms) };
	GlobalMemoryStatus(&ms);

	cout << "TotalPhys     " << ms.dwTotalPhys / 1024 /1024 << "mB" << endl; //общий объем физи ческой (оперативной) памяти
	cout << "AvailPhys     " << ms.dwAvailPhys / 1024 / 1024 << "mB" << endl; //свободной физи ческой памяти.
	cout << "TotalPageFile " << ms.dwTotalPageFile / 1024 / 1024 << "mB" << endl; //максимальное количество байтов, которое может содержаться в страничном файле (файлах) на жестком диске (дисках)
	cout << "AvailPageFile " << ms.dwAvailPageFile / 1024 / 1024 << "mB" << endl; //файле свободно и может быть пе редано любому процессу.
	cout << "TotalVirtual  " << ms.dwTotalVirtual / 1024 / 1024 << "mB" << endl; //общее количе ство байтов, отведенных под закрытое адресное пространство процесса
	cout << "AvailVirtual  " << ms.dwAvailVirtual / 1024 / 1024 << "mB" << endl << endl; // байтов свободного адресного простран ства


	PINT pvMem = (PINT)VirtualAlloc(NULL, 1 * 1024 * 1024,  MEM_RESERVE | MEM_COMMIT, PAGE_READWRITE);
	//резервируем мегабайт виртуальной памяти и проецируем ее на физическую память
	pvMem[0] = 123;
	cout << pvMem[0] << endl;

	VirtualFree(pvMem, 0, MEM_RELEASE);

	system("pause");
	return 0;
}