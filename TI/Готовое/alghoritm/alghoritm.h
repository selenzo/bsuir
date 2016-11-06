#include <cstdlib>
using namespace std;
#include <iostream>
#include <fstream>

class Alghoritm
{
public:
    Alghoritm();
    ~Alghoritm();
    void Caesar(char* buffer, int bufferLength, int im);
    void Analyzer(char* buffer, int bufferLength, int *analyz);
    void SaveAnalyzToFile(char *inputPath, char* outputPath);
    void LoadTextAnalyz(char* inputPath);
    int Break(char *buffer, int bufferLength);
    int Break2(char* buffer, int bufferLength);
private:
    char Swap(char ch, int im);
    int Max(int* buffer);

    int* analyz = new int[256];
};
