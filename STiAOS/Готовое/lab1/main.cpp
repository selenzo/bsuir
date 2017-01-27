#include <stdio.h>
#include <tchar.h>
#include <iostream>
#include <iomanip>
#include <fstream>
#include <string.h>

using namespace std;

int main()
{
	int arr[255];
	for (int i = 0; i < 255; i++) {
		arr[i] = 0;
	}

	ifstream fileInput("lab1.txt");
	char buff[1000];
    fileInput.getline(buff, 1000);
	fileInput.close();
	for (int i = 0; i<strlen(buff); i++)
    {
		arr[buff[i]] +=1;
    }
	fstream fileOutput("out.txt", ios_base::out);
	int count = 0;
	for (int i =0; i< 255; i++) {
		if (arr[i] != 0) {
			count++;
			fileOutput << count << ". " << (char)i << " код ASCII " << i << " = " << arr[i] << endl;
		}
	}
	fileOutput << "итого: " << strlen(buff);
	fileOutput.close();
	return 0;
}


