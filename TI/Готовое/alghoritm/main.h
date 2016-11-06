#include <iostream>
#include <fstream>
#include <cstring>
#include "alghoritm.h"
using namespace std;

class Program
{
public:
    Program();
    ~Program();
    Program(int argc, char * argv[]);

private:
    void Save();
    int FileToBuffer();

    Alghoritm alghoritm;
    FILE *inputFile = NULL;
    FILE *outputFile = NULL;
    char* buffer = NULL;
    int bufferLength = 0;
    int im = 1;
    char* inputText = NULL;
    char* path = NULL;
    char* outputPath = new char[256];
    char* command = NULL;
};
