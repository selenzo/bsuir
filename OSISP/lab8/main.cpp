 #include "main.h"


int main(int argc, char *argv[])
{
	/*
	1L переводить в ждущий режим, но ничего не меняеться
	2L грубо выключает питание монитора
	*/
	PostMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, 2L);
	system("pause");

	return 0;
}