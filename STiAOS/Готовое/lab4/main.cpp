#include <stdio.h>
#include <unistd.h>
#include <iostream>
#include <iomanip>
#include <fstream>
#include <time.h>

using namespace std;

int main()
{
	time_t t;
    	time(&t);
	cout<<"Process"<<'\t'<<"Pid"<<'\t'<<"Parent Pid"<<endl;
	for (int i =0; i<2; i++)
	{
		pid_t pid = fork();
		if (pid == 0)
		{
			cout<<"Children process"<<'\t'<<getpid()<<'\t'<<getppid()<<'\t'<<ctime(&t)<<endl;
		}
		cin.get();
	}
	return 0;
}
