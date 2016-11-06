#include "main.h"

int main(int argc, char * argv[])
{
// 65 90 A Z
// 97 122 a z
    Program program(argc, argv);

    //Alghoritm alg;

    //alg.SaveAnalyzToFile("text.txt","textAnalyz.txt");

    //alg.LoadTextAnalyz("textAnalyz.txt");

    return 0;
}

Program::Program()
{
    path = "input.txt";
}

Program::~Program()
{
    if(inputFile)
    {
        fclose(inputFile);
    }
    if (outputFile)
    {
        fclose(outputFile);
    }
    delete(buffer);
}

Program::Program(int argc, char * argv[])
{

    if(argc == 6)
    {
        if (!strcmp(argv[1], "-s"))
        {
            im = atoi(argv[2]);
        }

        if (!strcmp(argv[4], "-f"))
        {
            path = argv[5];
        }

        inputFile = fopen(path, "r");
        bufferLength = FileToBuffer();

        if (!strcmp(argv[3], "-c"))
        {
            command = "coded_";
            alghoritm.Caesar(buffer, bufferLength, im);
        }
        if (!strcmp(argv[3], "-d"))
        {
            command = "decoded_";
            alghoritm.Caesar(buffer, bufferLength, 26 - im);
        }
        if (!strcmp(argv[3], "-b"))
        {
            command = "break_";
            int key = alghoritm.Break(buffer, bufferLength);
            alghoritm.Caesar(buffer, bufferLength, 26 - key);
            cout << "key is " << key << endl;
            ///////
        }
        Save();
    }

    if(argc == 4)
    {
        if (!strcmp(argv[1], "-a"))
        {
            alghoritm.SaveAnalyzToFile(argv[2], argv[3]);
        }

    }

    //path = "input.txt";
    //-s im -c +
    //-s im -d +
    //-s im -c -f file
    //-s im -d -f file

}

void Program::Save()
{
    strcpy(outputPath, command);
    strcat(outputPath, path);
    outputFile = fopen(outputPath, "w");
    fwrite(buffer, 1, bufferLength-4, outputFile);
}

int Program::FileToBuffer()
{
    fseek(inputFile, 0L, SEEK_END);
    int length = ftell(inputFile);
    rewind(inputFile);

    buffer = new char[length - 1];

    fread(buffer, 1, length, inputFile);
    return length;
}
