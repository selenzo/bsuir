#include <stdio.h>
#include <vector>
#include <unistd.h>
#include <iostream>
#include <iomanip>
#include <fstream>
#include <string.h>
#include <sys/stat.h>
#include <sys/types.h>
#include <dirent.h>
#include <wait.h>
#include <map>


using namespace std;

bool ArrayEqual (char*  a, char* b) {
    for (int i = 0; i < sizeof a; i++)
    {
        if (a[i] != b[i]) return false;
    }
    return true;
}

void SeeBytes(string url) {
    ifstream inputFile(url.c_str(), ifstream::binary);
    char arrayKey[4] = {'r','d','c','t'};
    char arrayTemp[sizeof arrayKey];
    inputFile.seekg(0,inputFile.end);
    int length = inputFile.tellg();
    int countEquals = 0;
    for (int i = 0; i < length - sizeof arrayTemp + 1; i++) {
        inputFile.seekg(i, inputFile.beg);
        inputFile.read((char*)&arrayTemp, sizeof arrayTemp);
        countEquals += (int) ArrayEqual(arrayKey, arrayTemp);
    }
    inputFile.close();
    cout << "PID: " << getpid() << '\t' << "File: " << url << '\t' << '\t' << '\t' << "Bytes: " << length << '\t' << "Equals: " << countEquals << endl;
}

int isFile(const char *path)
{
    struct stat path_stat;
    stat(path, &path_stat);
    return S_ISREG(path_stat.st_mode);
}

void FF(int cur, vector<string> files, int deep) {
    pid_t pid;
    int status;
    if(cur < files.size()) {
        if(deep == 0) {
            SeeBytes(files[cur]);
        } else {
            switch (pid = fork()) {
            case 0:
                FF(++cur, files,--deep);
                exit(42);
            break;
            default:
                waitpid(pid, &status, WSTOPPED);
                SeeBytes(files[cur]);
            }
        }
    }
}

int main()
{
    DIR *dir;
    struct dirent *entry;
    struct stat statbuf;
    string url = "d:\\work\\github\\bsuir\\STiAOS\\Готовое\\lab4";
    vector<string> files;
    dir = opendir(url.c_str());
    int deepMax = 3;

    while ( (entry = readdir(dir)) != NULL) {
        if (isFile(entry->d_name)) {
                files.push_back(entry->d_name);
        }
    };
    closedir(dir);

    int current = 0;
    int maxDeep = 2;

     while(current < files.size()) {
        FF(current, files, maxDeep);
        current +=maxDeep + 1;
     }
	return 0;
}
