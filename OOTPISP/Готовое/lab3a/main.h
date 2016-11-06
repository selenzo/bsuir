#include <iostream>
#include <string>

using namespace std;

class String
{
public:
	String();
	~String();
	void SetString(string);
	string GetString();
	String& operator= (const String&);
	String& operator= (char*);
	String& operator+= (const String&);
	String& operator+= (char*);
	char& operator[] (int);
private:
	string str;
};
