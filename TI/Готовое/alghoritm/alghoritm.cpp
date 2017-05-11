#include "alghoritm.h"

Alghoritm::Alghoritm()
{
    for (int i = 0; i < 256; i++)
    {
        analyz[i] = 0;
    }
};
Alghoritm::~Alghoritm()
{
    delete(analyz);
}

void Alghoritm::SaveAnalyzToFile(char* inputPath, char* outputPath)
{
    FILE* input = fopen(inputPath, "r");

    ofstream output(outputPath);

    fseek(input, 0L, SEEK_END);
    int length = ftell(input);
    rewind(input);
    char *buf = new char[length - 1];

    fread(buf, 1, length, input);

    Analyzer(buf, length, analyz);

    for (int i = 0; i < 256; i++)
    {
        if (analyz[i] != 0)
        {
            output << (char)i <<" "<< analyz[i] << endl;
        }
    }

    fclose(input);
    delete(buf);
    output.close();
}

void Alghoritm::LoadTextAnalyz(char * inputPath)
{
    ifstream input(inputPath);

    char tmpC;
    int tmpI;

    while(!input.eof())
    {
        input >> tmpC >> tmpI;
        analyz[(int)tmpC] = tmpI;
    }

    input.close();

    //for (int i=0; i < 256; i++)
    //{
    //  cout << analyz[i] << endl;
    //}
}

void Alghoritm::Caesar(char* buffer, int bufferLength, int im)
{
    int tmp;
    for (int i = 0; i < bufferLength; i++)
    {
        if (isalpha(buffer[i]))
        {
            tmp = im;
            tmp -= ((int)buffer[i] + im > 122 || (isupper(buffer[i]) && (int)buffer[i] + im > 90 ) ? 26 : 0);
            buffer[i] = (char)((int)buffer[i] + tmp);
        }
    }
}

void Alghoritm::Analyzer(char* buffer, int bufferLength, int *analyz)
{
    for (int i = 0; i < bufferLength; i++)
    {
        if (isalpha(buffer[i]))
        {
            analyz[(int)buffer[i]] +=1;
        }
    }
}

int Alghoritm::Break(char* buffer, int bufferLength)
{
    LoadTextAnalyz("textAnalyz.txt");
    int *tmpBuf = new int[256];
    int *tmpAnalyz = new int[256];

    for (int i = 0; i < 256; i++)
    {
        tmpBuf[i] = 0;
        tmpAnalyz[i] = analyz[i];
    }

    Analyzer(buffer, bufferLength, tmpBuf);

    int maxAnalyz = Max (tmpAnalyz);
    int maxBuf = Max(tmpBuf);
    int tmpKey = 0;

    if(maxBuf > maxAnalyz)
    {
        tmpKey = maxBuf - maxAnalyz;
    }
    else
    {
        tmpKey = 26 - (maxAnalyz - maxBuf);
    }
    return tmpKey;
}

int Alghoritm::Break2(char* buffer, int bufferLength)
{
    LoadTextAnalyz("textAnalyz.txt");
    int keys[26];
    int sm = 0; //смещение по максимальному
    bool ok1 = true;
    bool ok2 = true;
    for (int i = 0; i < 26; i++)
    {
        keys[i] = 0;
    }

    while(sm < 26)
    {
        cout << " sm " << sm << " " << endl;
        int *tmpBuf = new int[256];
        int *tmpAnalyz = new int[256];

        for (int i = 0; i < 256; i++)
        {
            tmpBuf[i] = 0;
            tmpAnalyz[i] = analyz[i];
        }

        Analyzer(buffer, bufferLength, tmpBuf);
        ok2 = true;

        int maxAnalyz = Max (tmpAnalyz);
        int maxBuf = Max(tmpBuf);
        int tmpSm = sm;
        while (tmpSm > 0 && maxBuf > 0)
        {
            tmpBuf[maxBuf] = 0;
            maxBuf = Max(tmpBuf);
            tmpSm--;
        }

        while(ok2)
        {
            ok1 = true;
            maxBuf = Max(tmpBuf);
            maxAnalyz = Max (tmpAnalyz);

            if(tmpBuf[maxBuf] == 0)
            {
                ok2 = false;
            }

            int tmpKey = 0;
            cout << " ! " << (char)maxBuf << " " << (char)maxAnalyz << " " << (isupper((char)maxBuf) && isupper((char)maxAnalyz))<< endl;
            if (isupper((char)maxBuf) == isupper((char)maxAnalyz))
            {
                if(maxBuf > maxAnalyz)
                {
                    tmpKey = maxBuf - maxAnalyz;
                }
                else
                {
                    tmpKey = 26 - (maxAnalyz - maxBuf);
                }
                keys[tmpKey] += 1;
            }
            else
            {
                tmpBuf[maxBuf] = 0;
                ok1 = false;
            }

            while(ok1)
            {
                if ((isupper(maxBuf) == isupper(maxAnalyz)) && maxBuf != 0)
                {

                    bool can = true;
                    while(can)
                    {

                        maxAnalyz = Max (tmpAnalyz);
                        maxBuf = Max(tmpBuf);
                        cout << " ! " << (char)maxBuf << " " << (char)maxAnalyz << " " << endl;
                        if(Swap(tmpBuf[maxBuf], tmpKey) == (char)maxAnalyz)
                        {
                            keys[tmpKey] += 1;
                        }

                        if(tmpAnalyz[maxAnalyz] == 0 || tmpBuf[maxBuf] == 0)
                        {
                            can = false;
                            ok1 = false;
                        }
                        tmpBuf[maxBuf] = 0;
                        tmpAnalyz[maxAnalyz] = 0;
                    }
                }
                if(tmpBuf[maxBuf] == 0)
                {
                    ok1 = false;
                }
                tmpAnalyz[maxAnalyz] = 0;
                tmpBuf[maxBuf] = 0;
            }



        }
        sm++;
    }

    int mx = 0;
    int mxI=0;
    for (int i = 0; i < 26; i++)
    {
        cout << i << " " << keys[i] << endl;
        if (keys[i] > mx)
        {
            mx = keys[i];
            mxI = i;
        }
    }
    return mxI;
}

char Alghoritm::Swap(char ch, int im)
{
    int tmp;

    if (isalpha(ch))
    {
        tmp = im;
        tmp -= ((int)ch + im > 122 || (isupper(ch) && (int)ch + im > 90 ) ? 26 : 0);
        return (char)((int)ch + tmp);
    }
    return ch;
}

int Alghoritm::Max(int* buffer)
{
    int tmp = 0;
    int tmpI = 0;
    int i = 0;
    for (i=0; i <256; i++)
    {
        if (buffer[i] > tmp )
        {
            tmp = buffer[i];
            tmpI = i;
        }
    }
    return tmpI;
}
